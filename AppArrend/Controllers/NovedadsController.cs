using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppArrend.Models;

namespace AppArrend.Controllers
{
    public class NovedadsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Novedads
        public async Task<ActionResult> Index()
        {
            return View(await db.Novedades.ToListAsync());
        }

        // GET: Novedads/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Novedad novedad = await db.Novedades.FindAsync(id);
            if (novedad == null)
            {
                return HttpNotFound();
            }
            return View(novedad);
        }

        // GET: Novedads/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Novedads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Descripcion,Tipo")] Novedad novedad)
        {
            if (ModelState.IsValid)
            {
                db.Novedades.Add(novedad);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(novedad);
        }

        // GET: Novedads/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Novedad novedad = await db.Novedades.FindAsync(id);
            if (novedad == null)
            {
                return HttpNotFound();
            }
            return View(novedad);
        }

        // POST: Novedads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Descripcion,Tipo")] Novedad novedad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(novedad).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(novedad);
        }

        // GET: Novedads/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Novedad novedad = await db.Novedades.FindAsync(id);
            if (novedad == null)
            {
                return HttpNotFound();
            }
            return View(novedad);
        }

        // POST: Novedads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Novedad novedad = await db.Novedades.FindAsync(id);
            db.Novedades.Remove(novedad);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

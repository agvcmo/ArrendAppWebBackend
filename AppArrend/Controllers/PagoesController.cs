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
    public class PagoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pagoes
        public async Task<ActionResult> Index()
        {
            var pagos = db.Pagos.Include(p => p.InmueblePago);
            return View(await pagos.ToListAsync());
        }

        // GET: Pagoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pago pago = await db.Pagos.FindAsync(id);
            if (pago == null)
            {
                return HttpNotFound();
            }
            return View(pago);
        }

        // GET: Pagoes/Create
        public ActionResult Create()
        {
            ViewBag.InmueblePagoID = new SelectList(db.Inmuebles, "Id", "Direccion");
            return View();
        }

        // POST: Pagoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Fecha,MedioDePago,InmueblePagoID")] Pago pago)
        {
            if (ModelState.IsValid)
            {
                db.Pagos.Add(pago);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.InmueblePagoID = new SelectList(db.Inmuebles, "Id", "Direccion", pago.InmueblePagoID);
            return View(pago);
        }

        // GET: Pagoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pago pago = await db.Pagos.FindAsync(id);
            if (pago == null)
            {
                return HttpNotFound();
            }
            ViewBag.InmueblePagoID = new SelectList(db.Inmuebles, "Id", "Direccion", pago.InmueblePagoID);
            return View(pago);
        }

        // POST: Pagoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Fecha,MedioDePago,InmueblePagoID")] Pago pago)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pago).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.InmueblePagoID = new SelectList(db.Inmuebles, "Id", "Direccion", pago.InmueblePagoID);
            return View(pago);
        }

        // GET: Pagoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pago pago = await db.Pagos.FindAsync(id);
            if (pago == null)
            {
                return HttpNotFound();
            }
            return View(pago);
        }

        // POST: Pagoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Pago pago = await db.Pagos.FindAsync(id);
            db.Pagos.Remove(pago);
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

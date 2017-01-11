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
    public class ArrendatariosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Arrendatarios
        public async Task<ActionResult> Index()
        {
            return View(await db.Usuarios.ToListAsync());
        }

        // GET: Arrendatarios/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arrendatario arrendatario = await db.Arrendatarios.FindAsync(id);
            if (arrendatario == null)
            {
                return HttpNotFound();
            }
            return View(arrendatario);
        }

        // GET: Arrendatarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Arrendatarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nombre,Apellido,SegundoApellido,NombreUsuario,Clave,Telefono,Celular,Direccion,Correo,Edad,Genero,Tipo")] Arrendatario arrendatario)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(arrendatario);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(arrendatario);
        }

        // GET: Arrendatarios/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arrendatario arrendatario = await db.Arrendatarios.FindAsync(id);
            if (arrendatario == null)
            {
                return HttpNotFound();
            }
            return View(arrendatario);
        }

        // POST: Arrendatarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nombre,Apellido,SegundoApellido,NombreUsuario,Clave,Telefono,Celular,Direccion,Correo,Edad,Genero,Tipo")] Arrendatario arrendatario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arrendatario).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(arrendatario);
        }

        // GET: Arrendatarios/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arrendatario arrendatario = await db.Arrendatarios.FindAsync(id);
            if (arrendatario == null)
            {
                return HttpNotFound();
            }
            return View(arrendatario);
        }

        // POST: Arrendatarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Arrendatario arrendatario = await db.Arrendatarios.FindAsync(id);
            db.Usuarios.Remove(arrendatario);
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

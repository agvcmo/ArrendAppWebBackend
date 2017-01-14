using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AppArrendBackend.Models;
using Modelo.Modelo;

namespace AppArrendBackend.Controllers
{
    public class ArchivoesController : ApiController
    {
        private AppArrendContext db = new AppArrendContext();

        // GET: api/Archivoes
        public IQueryable<Archivo> GetArchivoes()
        {
            return db.Archivoes;
        }

        // GET: api/Archivoes/5
        [ResponseType(typeof(Archivo))]
        public async Task<IHttpActionResult> GetArchivo(int id)
        {
            Archivo archivo = await db.Archivoes.FindAsync(id);
            if (archivo == null)
            {
                return NotFound();
            }

            return Ok(archivo);
        }

        // PUT: api/Archivoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutArchivo(int id, Archivo archivo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != archivo.Id)
            {
                return BadRequest();
            }

            db.Entry(archivo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArchivoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Archivoes
        [ResponseType(typeof(Archivo))]
        public async Task<IHttpActionResult> PostArchivo(Archivo archivo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Archivoes.Add(archivo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = archivo.Id }, archivo);
        }

        // DELETE: api/Archivoes/5
        [ResponseType(typeof(Archivo))]
        public async Task<IHttpActionResult> DeleteArchivo(int id)
        {
            Archivo archivo = await db.Archivoes.FindAsync(id);
            if (archivo == null)
            {
                return NotFound();
            }

            db.Archivoes.Remove(archivo);
            await db.SaveChangesAsync();

            return Ok(archivo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ArchivoExists(int id)
        {
            return db.Archivoes.Count(e => e.Id == id) > 0;
        }
    }
}
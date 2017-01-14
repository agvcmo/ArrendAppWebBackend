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
    public class NovedadsController : ApiController
    {
        private AppArrendContext db = new AppArrendContext();

        // GET: api/Novedads
        public IQueryable<Novedad> GetNovedads()
        {
            return db.Novedads;
        }

        // GET: api/Novedads/5
        [ResponseType(typeof(Novedad))]
        public async Task<IHttpActionResult> GetNovedad(int id)
        {
            Novedad novedad = await db.Novedads.FindAsync(id);
            if (novedad == null)
            {
                return NotFound();
            }

            return Ok(novedad);
        }

        // PUT: api/Novedads/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNovedad(int id, Novedad novedad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != novedad.Id)
            {
                return BadRequest();
            }

            db.Entry(novedad).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NovedadExists(id))
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

        // POST: api/Novedads
        [ResponseType(typeof(Novedad))]
        public async Task<IHttpActionResult> PostNovedad(Novedad novedad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Novedads.Add(novedad);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = novedad.Id }, novedad);
        }

        // DELETE: api/Novedads/5
        [ResponseType(typeof(Novedad))]
        public async Task<IHttpActionResult> DeleteNovedad(int id)
        {
            Novedad novedad = await db.Novedads.FindAsync(id);
            if (novedad == null)
            {
                return NotFound();
            }

            db.Novedads.Remove(novedad);
            await db.SaveChangesAsync();

            return Ok(novedad);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NovedadExists(int id)
        {
            return db.Novedads.Count(e => e.Id == id) > 0;
        }
    }
}
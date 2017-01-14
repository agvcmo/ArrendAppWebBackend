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
    public class PagoesController : ApiController
    {
        private AppArrendContext db = new AppArrendContext();

        // GET: api/Pagoes
        public IQueryable<Pago> GetPagoes()
        {
            return db.Pagoes;
        }

        // GET: api/Pagoes/5
        [ResponseType(typeof(Pago))]
        public async Task<IHttpActionResult> GetPago(int id)
        {
            Pago pago = await db.Pagoes.FindAsync(id);
            if (pago == null)
            {
                return NotFound();
            }

            return Ok(pago);
        }

        // PUT: api/Pagoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPago(int id, Pago pago)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pago.Id)
            {
                return BadRequest();
            }

            db.Entry(pago).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PagoExists(id))
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

        // POST: api/Pagoes
        [ResponseType(typeof(Pago))]
        public async Task<IHttpActionResult> PostPago(Pago pago)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pagoes.Add(pago);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = pago.Id }, pago);
        }

        // DELETE: api/Pagoes/5
        [ResponseType(typeof(Pago))]
        public async Task<IHttpActionResult> DeletePago(int id)
        {
            Pago pago = await db.Pagoes.FindAsync(id);
            if (pago == null)
            {
                return NotFound();
            }

            db.Pagoes.Remove(pago);
            await db.SaveChangesAsync();

            return Ok(pago);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PagoExists(int id)
        {
            return db.Pagoes.Count(e => e.Id == id) > 0;
        }
    }
}
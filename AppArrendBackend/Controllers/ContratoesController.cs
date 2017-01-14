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
    public class ContratoesController : ApiController
    {
        private AppArrendContext db = new AppArrendContext();

        // GET: api/Contratoes
        public IQueryable<Contrato> GetContratoes()
        {
            return db.Contratoes;
        }

        // GET: api/Contratoes/5
        [ResponseType(typeof(Contrato))]
        public async Task<IHttpActionResult> GetContrato(int id)
        {
            Contrato contrato = await db.Contratoes.FindAsync(id);
            if (contrato == null)
            {
                return NotFound();
            }

            return Ok(contrato);
        }

        // PUT: api/Contratoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutContrato(int id, Contrato contrato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contrato.Id)
            {
                return BadRequest();
            }

            db.Entry(contrato).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContratoExists(id))
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

        // POST: api/Contratoes
        [ResponseType(typeof(Contrato))]
        public async Task<IHttpActionResult> PostContrato(Contrato contrato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Contratoes.Add(contrato);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = contrato.Id }, contrato);
        }

        // DELETE: api/Contratoes/5
        [ResponseType(typeof(Contrato))]
        public async Task<IHttpActionResult> DeleteContrato(int id)
        {
            Contrato contrato = await db.Contratoes.FindAsync(id);
            if (contrato == null)
            {
                return NotFound();
            }

            db.Contratoes.Remove(contrato);
            await db.SaveChangesAsync();

            return Ok(contrato);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContratoExists(int id)
        {
            return db.Contratoes.Count(e => e.Id == id) > 0;
        }
    }
}
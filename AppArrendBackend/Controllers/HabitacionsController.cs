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
    public class HabitacionsController : ApiController
    {
        private AppArrendContext db = new AppArrendContext();

        // GET: api/Habitacions
        public IQueryable<Habitacion> GetHabitacions()
        {
            return db.Habitacions;
        }

        // GET: api/Habitacions/5
        [ResponseType(typeof(Habitacion))]
        public async Task<IHttpActionResult> GetHabitacion(int id)
        {
            Habitacion habitacion = await db.Habitacions.FindAsync(id);
            if (habitacion == null)
            {
                return NotFound();
            }

            return Ok(habitacion);
        }

        // PUT: api/Habitacions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHabitacion(int id, Habitacion habitacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != habitacion.Id)
            {
                return BadRequest();
            }

            db.Entry(habitacion).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HabitacionExists(id))
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

        // POST: api/Habitacions
        [ResponseType(typeof(Habitacion))]
        public async Task<IHttpActionResult> PostHabitacion(Habitacion habitacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Habitacions.Add(habitacion);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = habitacion.Id }, habitacion);
        }

        // DELETE: api/Habitacions/5
        [ResponseType(typeof(Habitacion))]
        public async Task<IHttpActionResult> DeleteHabitacion(int id)
        {
            Habitacion habitacion = await db.Habitacions.FindAsync(id);
            if (habitacion == null)
            {
                return NotFound();
            }

            db.Habitacions.Remove(habitacion);
            await db.SaveChangesAsync();

            return Ok(habitacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HabitacionExists(int id)
        {
            return db.Habitacions.Count(e => e.Id == id) > 0;
        }
    }
}
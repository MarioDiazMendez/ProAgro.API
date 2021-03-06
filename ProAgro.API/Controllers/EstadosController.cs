using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ProAgro.API.Context;

namespace ProAgro.API.Controllers
{
    public class EstadosController : ApiController
    {
        private modelo db = new modelo();

        // GET: api/Estados
        public IQueryable<Estados> GetEstados()
        {
            return db.Estados;
        }

        // GET: api/Estados/5
        [ResponseType(typeof(Estados))]
        public IHttpActionResult GetEstados(int id)
        {
            Estados estados = db.Estados.Find(id);
            if (estados == null)
            {
                return NotFound();
            }

            return Ok(estados);
        }

        // PUT: api/Estados/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEstados(int id, Estados estados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estados.idEstado)
            {
                return BadRequest();
            }

            db.Entry(estados).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
                return Ok(estados);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(HttpStatusCode.NoContent);
                }
            }

        }

        // POST: api/Estados
        [ResponseType(typeof(Estados))]
        public IHttpActionResult PostEstados(Estados estados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Estados.Add(estados);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = estados.idEstado }, estados);
        }

        // DELETE: api/Estados/5
        [ResponseType(typeof(Estados))]
        public IHttpActionResult DeleteEstados(int id)
        {
            Estados estados = db.Estados.Find(id);
            if (estados == null)
            {
                return NotFound();
            }

            db.Estados.Remove(estados);
            db.SaveChanges();

            return Ok(estados);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EstadosExists(int id)
        {
            return db.Estados.Count(e => e.idEstado == id) > 0;
        }
    }
}
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
    public class GeorreferenciasxEstadoController : ApiController
    {
        private modelo db = new modelo();

        // GET: api/GeorreferenciasxEstado
        public IQueryable<Georreferencias> GetGeorreferencias()
        {
            return db.Georreferencias;
        }

        // GET: api/GeorreferenciasxEstado/5
        [ResponseType(typeof(GeorreferenciasMaps))]
        public IHttpActionResult GetGeorreferencias(int id)
        {
            var georreferencias = db.Georreferencias
                                .Where(x => x.idEstado == id)
                                .Select(x => new { 
                                    x.idEstado, 
                                    x.idGeorreferencia, 
                                    x.Latitud , 
                                    x.Longitud, 
                                    LatitudLongitud =  x.Latitud + " - " + x.Longitud 
                                })
                                .ToList();
            
            if (georreferencias == null)
            {
                return NotFound();
            }
            return Ok(georreferencias);

           
        }

        // PUT: api/GeorreferenciasxEstado/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGeorreferencias(int id, Georreferencias georreferencias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != georreferencias.idGeorreferencia)
            {
                return BadRequest();
            }

            db.Entry(georreferencias).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeorreferenciasExists(id))
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

        // POST: api/GeorreferenciasxEstado
        [ResponseType(typeof(Georreferencias))]
        public IHttpActionResult PostGeorreferencias(Georreferencias georreferencias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Georreferencias.Add(georreferencias);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = georreferencias.idGeorreferencia }, georreferencias);
        }

        // DELETE: api/GeorreferenciasxEstado/5
        [ResponseType(typeof(Georreferencias))]
        public IHttpActionResult DeleteGeorreferencias(int id)
        {
            Georreferencias georreferencias = db.Georreferencias.Find(id);
            if (georreferencias == null)
            {
                return NotFound();
            }

            db.Georreferencias.Remove(georreferencias);
            db.SaveChanges();

            return Ok(georreferencias);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GeorreferenciasExists(int id)
        {
            return db.Georreferencias.Count(e => e.idGeorreferencia == id) > 0;
        }
    }
}
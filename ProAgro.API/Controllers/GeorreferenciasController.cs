﻿using System;
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
    public class GeorreferenciasController : ApiController
    {
        private modelo db = new modelo();

        // GET: api/Georreferencias
        public IQueryable<Georreferencias> GetGeorreferencias()
        {
            return db.Georreferencias;
        }

        // GET: api/Georreferencias/5
        [ResponseType(typeof(Georreferencias))]
        public IHttpActionResult GetGeorreferencias(int id)
        {
            Georreferencias georreferencias = db.Georreferencias.Find(id);
            if (georreferencias == null)
            {
                return NotFound();
            }

            return Ok(georreferencias);
        }

        [HttpGet]
        public IHttpActionResult GetObtenerxEstado(int id)
        {
            Georreferencias georreferencias = db.Georreferencias.Find(id);
            if (georreferencias == null)
            {
                return NotFound();
            }

            return Ok(georreferencias);
        }

        // PUT: api/Georreferencias/5
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
                return Ok(georreferencias);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeorreferenciasExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(HttpStatusCode.NoContent);
                }
            }

        }

        // POST: api/Georreferencias
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

        // DELETE: api/Georreferencias/5
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
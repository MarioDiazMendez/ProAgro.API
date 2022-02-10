using ProAgro.API.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace ProAgro.API.Controllers
{
    public class PermisosController : ApiController
    {
        private modelo db = new modelo();



        // GET: api/Permisos
        public IQueryable<Permisos> GetPermisos()
        {
            return db.Permisos;
        }

        // GET: api/Permisos/5
      
        public IHttpActionResult GetPermisos(int id)
        {
            Permisos perEdoUser = db.Permisos.First(x => x.idUsuario == id);
            return Ok(perEdoUser);
        }

       

        // POST: api/Permisos
        [ResponseType(typeof(Permisos))]
        public IHttpActionResult PostPermisos(Permisos permisos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Permisos.Add(permisos);
            db.SaveChanges();

            return Ok();        
        }

        //[System.Web.Http.HttpPost]
        public IHttpActionResult DeletePermisos(Permisos permisos)
        {
            Permisos perEdoUser = db.Permisos.First(x => x.idEstado == permisos.idEstado && x.idUsuario == permisos.idUsuario);

            db.Permisos.Remove(perEdoUser);
            db.SaveChanges();

            return Json(new { result = "ok" });
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

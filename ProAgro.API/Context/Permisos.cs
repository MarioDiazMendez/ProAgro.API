using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProAgro.API.Context
{
    public class Permisos
    {
        public int idUsuario { get; set; }
        public Usuario Usuario { get; set; }

        public int idEstado { get; set; }
        public Estados Estados { get; set; }
    }
}
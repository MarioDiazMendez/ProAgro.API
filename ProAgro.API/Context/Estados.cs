namespace ProAgro.API.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Estados
    {
        [Key]
        public int idEstado { get; set; }

        [StringLength(50)]
        public string NombreEstado { get; set; }

        [StringLength(10)]
        public string Abreviatura { get; set; }

        public ICollection<Permisos> Permisos { get; set; }
    }
}

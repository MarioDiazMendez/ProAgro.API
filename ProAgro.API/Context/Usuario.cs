namespace ProAgro.API.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Usuario")]
    public partial class Usuario
    {
        [Key]
        public int idUsuario { get; set; }

        [StringLength(50)]
        public string Contrasena { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        public DateTime? FechaCreacion { get; set; }

        [StringLength(20)]
        public string RFC { get; set; }

        public ICollection<Permisos> Permisos { get; set; }
    }
}

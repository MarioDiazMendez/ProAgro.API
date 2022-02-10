namespace ProAgro.API.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Georreferencias
    {
        [Key]
        public int idGeorreferencia { get; set; }

        public int? idEstado { get; set; }

        [StringLength(50)]
        public string Latitud { get; set; }

        [StringLength(50)]
        public string Longitud { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ProAgro.API.Context
{
    public partial class modelo : DbContext
    {
        public modelo()
            : base("name=modelo")
        {
        }

        public virtual DbSet<Estados> Estados { get; set; }
        public virtual DbSet<Georreferencias> Georreferencias { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        public virtual DbSet<Permisos> Permisos { get; set;  }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estados>()
                .Property(e => e.NombreEstado)
                .IsUnicode(false);

            modelBuilder.Entity<Estados>()
                .Property(e => e.Abreviatura)
                .IsUnicode(false);

            modelBuilder.Entity<Georreferencias>()
                .Property(e => e.Latitud)
                .IsUnicode(false);

            modelBuilder.Entity<Georreferencias>()
                .Property(e => e.Longitud)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Contrasena)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.RFC)
                .IsUnicode(false);

            modelBuilder.Entity<Permisos>()
                .HasKey(bc => new { bc.idUsuario, bc.idEstado });

            modelBuilder.Entity<Permisos>()
                .HasRequired(bc => bc.Usuario)
                .WithMany(b => b.Permisos)
                .HasForeignKey(bc => bc.idUsuario);

            modelBuilder.Entity<Permisos>()
               .HasRequired(bc => bc.Estados)
               .WithMany(b => b.Permisos)
               .HasForeignKey(bc => bc.idEstado);


        }
    }
}

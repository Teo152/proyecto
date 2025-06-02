
using Lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace lib_repositorios.Implementaciones
{
    public partial class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
        public DbSet<Planes>?Planes { get; set; }
        public DbSet<Sedes>?Sedes { get; set; }

        public DbSet<Estados_pagos>? Estados_pagos { get; set; }

        public DbSet<Estados_Inscripciones>? Estados_Inscripciones { get; set; }

        public DbSet<Planes_Sedes>? Planes_Sedes { get; set; }

       public DbSet<Personas>? Personas { get; set; }

        public DbSet<Inscripciones>? Inscripciones { get; set; }

        public DbSet<Pagos>? Pagos { get; set; }

        public DbSet<Observaciones>? Observaciones {  get; set; }

        public DbSet<Empleados>? Empleados { get; set; }

        public DbSet<Usuarios>? Usuarios { get; set; }
        public DbSet<Roles>? Roles { get; set; }
        public DbSet<Permisos>? Permisos { get; set; }
        public DbSet<Roles_Permisos>? Roles_Permisos { get; set; }
        public DbSet<Auditoria>? Auditoria { get; set; }

    }
}
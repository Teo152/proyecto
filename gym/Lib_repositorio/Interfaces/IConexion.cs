
using Lib_dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace lib_repositorios.Interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }

        DbSet<Planes>? Planes { get; set; }
        DbSet<Sedes>? Sedes { get; set; }

        DbSet<Estados_pagos>? Estados_pagos { get; set; }

        DbSet<Estados_Inscripciones>? Estados_Inscripciones { get; set; }

        DbSet<Planes_Sedes>? Planes_Sedes { get; set; }

        DbSet<Personas>? Personas { get; set; }

        DbSet<Inscripciones>? Inscripciones { get; set; }

        DbSet<Pagos>? Pagos { get; set; }

        DbSet<Observaciones>? Observaciones { get; set; }

        DbSet<Empleados> Empleados { get; set; }

        DbSet<Usuarios>? Usuarios { get; set; }

        DbSet<Permisos>? Permisos { get; set; }
        DbSet<Roles>? Roles { get; set; }

        DbSet<Roles_Permisos>? Roles_Permisos { get; set; }

        DbSet<Auditoria>? Auditoria { get; set; }

        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}

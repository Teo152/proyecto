﻿
using lib_aplicaciones.Interfaces;
using Lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class Roles_PermisosAplicacion : IRoles_PermisosAplicacion
    {
        private IConexion? IConexion = null;

        public Roles_PermisosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Roles_Permisos? Borrar(Roles_Permisos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.id == 0)
                throw new Exception("lbNoSeGuardo");

            this.IConexion!.Roles_Permisos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Roles_Permisos? Guardar(Roles_Permisos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.id != 0)
                throw new Exception("lbYaSeGuardo");

            this.IConexion!.Roles_Permisos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Roles_Permisos> Listar()
        {
            return this.IConexion!.Roles_Permisos!.Take(20).ToList();
        }

        public List<Roles_Permisos> PorCodigo(Roles_Permisos? entidad)
        {
            return this.IConexion!.Roles_Permisos!
            .Where(x => x.codigo!.Contains(entidad!.codigo!))
            .ToList();
        }

        public Roles_Permisos? Modificar(Roles_Permisos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.id == 0)
                throw new Exception("lbNoSeGuardo");

            var entry = this.IConexion!.Entry<Roles_Permisos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }




    }
}

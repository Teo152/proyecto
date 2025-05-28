﻿using lib_aplicaciones.Interfaces;
using Lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class PersonasAplicacion : IPersonasAplicacion
    {
        private IConexion? IConexion = null;

        public PersonasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Personas? Borrar(Personas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.id == 0)
                throw new Exception("lbNoSeGuardo");

            this.IConexion!.Personas!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Personas? Guardar(Personas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.id != 0)
                throw new Exception("lbYaSeGuardo");

            this.IConexion!.Personas!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Personas> Listar()
        {
            return this.IConexion!.Personas!.Take(20).ToList();
        }

        public List<Personas> PorCodigo(Personas? entidad)
        {
            return this.IConexion!.Personas!
            .Where(x => x.nombre!.Contains(entidad!.nombre!))
            .ToList();
        }

        public Personas? Modificar(Personas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.id == 0)
                throw new Exception("lbNoSeGuardo");

            var entry = this.IConexion!.Entry<Personas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }




    }
}

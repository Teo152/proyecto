using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorio
{
    [TestClass]
    public class PermisosPrueba
    {
        private readonly IConexion? iConexion;
        private List<Permisos>? lista;
        private Permisos? entidad;

        public PermisosPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
        }

        [TestMethod]
        public void Ejecutar()
        {
            Assert.AreEqual(true, Guardar());
            Assert.AreEqual(true, Modificar());
            Assert.AreEqual(true, Listar());
            Assert.AreEqual(true, Borrar());
        }

        public bool Guardar()
        {
            this.entidad = new Permisos
            {
                nombre = "AccesoPanelControl",
            };

            this.iConexion!.Permisos!.Add(this.entidad);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            this.entidad!.nombre = "AccesoModificado";

            var entry = this.iConexion!.Entry<Permisos>(this.entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Listar()
        {
            this.lista = this.iConexion!.Permisos!.ToList();
            return lista.Count > 0;
        }

        public bool Borrar()
        {
            this.iConexion!.Permisos!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}

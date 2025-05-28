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
    public class Roles_PermisosPrueba
    {
        private readonly IConexion? iConexion;
        private List<Roles_Permisos>? lista;
        private Roles_Permisos? entidad;

        public Roles_PermisosPrueba()
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
            this.entidad = new Roles_Permisos
            {
                rol = 1,        // Id del rol existente
                permiso = 1     // Id del permiso existente
            };

            this.iConexion!.Roles_Permisos!.Add(this.entidad);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            this.entidad!.permiso = 2; // Cambiar el permiso, por ejemplo

            var entry = this.iConexion!.Entry<Roles_Permisos>(this.entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Listar()
        {
            this.lista = this.iConexion!.Roles_Permisos!.ToList();
            return lista.Count > 0;
        }

        public bool Borrar()
        {
            this.iConexion!.Roles_Permisos!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}



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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ut_presentacion.Repositorio
{
    [TestClass]
    public class AuditoriaPrueba
    {
        private readonly IConexion? iConexion;
        private List<Auditoria>? lista;
        private Auditoria? entidad;

        public AuditoriaPrueba()
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
            this.entidad = new Auditoria
            {
                Usuario = 1,
                FechaHora = DateTime.Now,
                Accion = "Creación de usuario"
            };

            this.iConexion!.Auditoria!.Add(this.entidad);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            this.entidad!.Accion = "Modificación de usuario";

            var entry = this.iConexion!.Entry<Auditoria>(this.entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Listar()
        {
            this.lista = this.iConexion!.Auditoria!.ToList();
            return lista.Count > 0;
        }

        public bool Borrar()
        {
            this.iConexion!.Auditoria!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}

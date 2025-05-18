

using Lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class PlanesPrueba
    {
        private readonly IConexion? iConexion;
        private List<Planes>? lista;
        private Planes? entidad;

        public PlanesPrueba()
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

        public bool Listar()
        {
            this.lista = this.iConexion!.Planes!.ToList();
            return lista.Count > 0;
        }



        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Planes()!;
            this.iConexion!.Planes!.Add(this.entidad);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            this.entidad!.precio = 100000.00m;

            var entry = this.iConexion!.Entry<Planes>(this.entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.Planes!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}
using lib_aplicaciones.Interfaces;
using Lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class Planes_SedesAplicacion : IPlanes_SedesAplicacion
    {
        private IConexion? IConexion = null;

        public Planes_SedesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Planes_Sedes? Borrar(Planes_Sedes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.id == 0)
                throw new Exception("lbNoSeGuardo");

            this.IConexion!.Planes_Sedes!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Planes_Sedes? Guardar(Planes_Sedes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.id != 0)
                throw new Exception("lbYaSeGuardo");

            this.IConexion!.Planes_Sedes!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Planes_Sedes> Listar()
        {
            return this.IConexion!.Planes_Sedes!.Take(20).ToList();
        }

        public List<Planes_Sedes> PorCodigo(Planes_Sedes? entidad)
        {
            return this.IConexion!.Planes_Sedes!
            .Where(x => x.tipo_acceso!.Contains(entidad!.tipo_acceso!))
            .ToList();
        }

        public Planes_Sedes? Modificar(Planes_Sedes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.id == 0)
                throw new Exception("lbNoSeGuardo");

            var entry = this.IConexion!.Entry<Planes_Sedes>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

     
    }
}

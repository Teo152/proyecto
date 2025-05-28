using lib_aplicaciones.Interfaces;
using Lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class Estados_InscripcionesAplicacion : IEstados_InscripcionesAplicacion
    {
        private IConexion? IConexion = null;

        public Estados_InscripcionesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Estados_Inscripciones? Borrar(Estados_Inscripciones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.id == 0)
                throw new Exception("lbNoSeGuardo");

            this.IConexion!.Estados_Inscripciones!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Estados_Inscripciones? Guardar(Estados_Inscripciones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.id != 0)
                throw new Exception("lbYaSeGuardo");

            this.IConexion!.Estados_Inscripciones!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Estados_Inscripciones> Listar()
        {
            return this.IConexion!.Estados_Inscripciones!.Take(20).ToList();
        }

        public List<Estados_Inscripciones> PorCodigo(Estados_Inscripciones? entidad)
        {
            return this.IConexion!.Estados_Inscripciones!
            .Where(x => x.estado!.Contains(entidad!.estado!))
            .ToList();
        }

        public Estados_Inscripciones? Modificar(Estados_Inscripciones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.id == 0)
                throw new Exception("lbNoSeGuardo");

            var entry = this.IConexion!.Entry<Estados_Inscripciones>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }




    }
}

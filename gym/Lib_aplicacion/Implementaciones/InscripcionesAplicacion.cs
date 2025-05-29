using lib_aplicaciones.Interfaces;
using Lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class InscripcionesAplicacion : IInscripcionesAplicacion
    {
        private IConexion? IConexion = null;

        public InscripcionesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Inscripciones? Borrar(Inscripciones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.id == 0)
                throw new Exception("lbNoSeGuardo");

            GuardarAuditoria("Se eliminó una Inscripción.");

            this.IConexion!.Inscripciones!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Inscripciones? Guardar(Inscripciones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.id != 0)
                throw new Exception("lbYaSeGuardo");

            GuardarAuditoria("Se guardó una nueva Inscripción.");

            this.IConexion!.Inscripciones!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Inscripciones> Listar()
        {
            return this.IConexion!.Inscripciones!.Take(20).ToList();
        }

        public List<Inscripciones> PorCodigo(Inscripciones? entidad)
        {
            return this.IConexion!.Inscripciones!
            .Where(x => x.codigo!.Contains(entidad!.codigo!))
            .ToList();
        }

        public Inscripciones? Modificar(Inscripciones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.id == 0)
                throw new Exception("lbNoSeGuardo");

            GuardarAuditoria("Se modificó una Inscripción.");

            var entry = this.IConexion!.Entry<Inscripciones>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public void GuardarAuditoria(string? accion)
        {
            var con = this.IConexion.Auditoria;
            var entidad = new Auditoria();
            {
                entidad.Usuario = 1;
                entidad.Accion = accion;
                entidad.FechaHora = DateTime.Now;
            }
            ;
            this.IConexion.Auditoria.Add(entidad);


        }


    }
}

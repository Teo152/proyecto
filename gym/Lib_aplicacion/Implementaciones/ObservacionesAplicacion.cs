using lib_aplicaciones.Interfaces;
using Lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class ObservacionesAplicacion : IObservacionesAplicacion
    {
        private IConexion? IConexion = null;

        public ObservacionesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Observaciones? Borrar(Observaciones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.id == 0)
                throw new Exception("lbNoSeGuardo");

            GuardarAuditoria("Se eliminó una Observación.");

            this.IConexion!.Observaciones!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Observaciones? Guardar(Observaciones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.id != 0)
                throw new Exception("lbYaSeGuardo");

            GuardarAuditoria("Se guardó una nueva Observación.");

            this.IConexion!.Observaciones!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Observaciones> Listar()
        {
            return this.IConexion!.Observaciones!.Take(20).ToList();
        }

        public List<Observaciones> PorDescripcion(Observaciones? entidad)
        {
            return this.IConexion!.Observaciones!
            .Where(x => x.descripcion!.Contains(entidad!.descripcion!))
            .ToList();
        }

        public Observaciones? Modificar(Observaciones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.id == 0)
                throw new Exception("lbNoSeGuardo");

            GuardarAuditoria("Se modificó una Observación.");

            var entry = this.IConexion!.Entry<Observaciones>(entidad);
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

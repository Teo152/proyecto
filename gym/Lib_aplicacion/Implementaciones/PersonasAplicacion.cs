using lib_aplicaciones.Interfaces;
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

            GuardarAuditoria("Se eliminó una Persona.");

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

            GuardarAuditoria("Se guardó una nueva Persona.");

            this.IConexion!.Personas!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Personas> Listar()
        {
            return this.IConexion!.Personas!.Take(20).ToList();
        }

        public List<Personas> PorNombre(Personas? entidad)
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

            GuardarAuditoria("Se modificó una Persona.");

            var entry = this.IConexion!.Entry<Personas>(entidad);
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

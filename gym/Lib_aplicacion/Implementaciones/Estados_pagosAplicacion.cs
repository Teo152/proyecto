using lib_aplicaciones.Interfaces;
using Lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class Estados_pagosAplicacion : IEstados_pagosAplicacion
    {
        private IConexion? IConexion = null;

        public Estados_pagosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Estados_pagos? Borrar(Estados_pagos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.id == 0)
                throw new Exception("lbNoSeGuardo");

            GuardarAuditoria("Se eliminó un Estado de Pago.");

            this.IConexion!.Estados_pagos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Estados_pagos? Guardar(Estados_pagos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.id != 0)
                throw new Exception("lbYaSeGuardo");

            GuardarAuditoria("Se guardó un nuevo Estado de Pago.");

            this.IConexion!.Estados_pagos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Estados_pagos> Listar()
        {
            return this.IConexion!.Estados_pagos!.Take(20).ToList();
        }

        public List<Estados_pagos> PorEstado(Estados_pagos? entidad)
        {
            return this.IConexion!.Estados_pagos!
            .Where(x => x.estado!.Contains(entidad!.estado!))
            .ToList();
        }

        public Estados_pagos? Modificar(Estados_pagos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.id == 0)
                throw new Exception("lbNoSeGuardo");

            GuardarAuditoria("Se modificó un Estado de Pago.");

            var entry = this.IConexion!.Entry<Estados_pagos>(entidad);
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


using lib_aplicaciones.Interfaces;
using Lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class AuditoriaAplicacion : IAuditoriaAplicacion
    {
        private IConexion? IConexion = null;

        public AuditoriaAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

       

        public List<Auditoria> Listar()
        {
            return this.IConexion!.Auditoria!.Take(20).ToList();
        }

       




    }
}

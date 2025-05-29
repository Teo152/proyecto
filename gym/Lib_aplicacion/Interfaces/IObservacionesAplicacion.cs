
using Lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IObservacionesAplicacion
    {
        void Configurar(string StringConexion);
        List<Observaciones> PorDescripcion(Observaciones? entidad);
        List<Observaciones> Listar();
        Observaciones? Guardar(Observaciones? entidad);

        Observaciones? Modificar(Observaciones? entidad);
        Observaciones? Borrar(Observaciones? entidad);
    }
}
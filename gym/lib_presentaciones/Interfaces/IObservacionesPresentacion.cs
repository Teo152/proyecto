using Lib_dominio.Entidades;
namespace lib_presentaciones.Interfaces
{
    public interface IObservacionesPresentacion
    {
        Task<List<Observaciones>> Listar();
        Task<List<Observaciones>> PorDescripcion(Observaciones? entidad);
        Task<Observaciones?> Guardar(Observaciones? entidad);
        Task<Observaciones?> Modificar(Observaciones? entidad);
        Task<Observaciones?> Borrar(Observaciones? entidad);
    }
}
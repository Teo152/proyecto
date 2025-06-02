using Lib_dominio.Entidades;
namespace lib_presentaciones.Interfaces
{
    public interface IPlanesPresentacion
    {
        Task<List<Planes>> Listar();
        Task<List<Planes>> PorNombre(Planes? entidad);
        Task<Planes?> Guardar(Planes? entidad);
        Task<Planes?> Modificar(Planes? entidad);
        Task<Planes?> Borrar(Planes? entidad);
    }
}
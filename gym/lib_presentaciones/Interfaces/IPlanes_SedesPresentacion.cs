using Lib_dominio.Entidades;
namespace lib_presentaciones.Interfaces
{
    public interface IPlanes_SedesPresentacion
    {
        Task<List<Planes_Sedes>> Listar();
        Task<List<Planes_Sedes>> PorTipoAcceso(Planes_Sedes? entidad);
        Task<Planes_Sedes?> Guardar(Planes_Sedes? entidad);
        Task<Planes_Sedes?> Modificar(Planes_Sedes? entidad);
        Task<Planes_Sedes?> Borrar(Planes_Sedes? entidad);
    }
}
using Lib_dominio.Entidades;
namespace lib_presentaciones.Interfaces
{
    public interface ISedesPresentacion
    {
        Task<List<Sedes>> Listar();
        Task<List<Sedes>> PorNombre(Sedes? entidad);
        Task<Sedes?> Guardar(Sedes? entidad);
        Task<Sedes?> Modificar(Sedes? entidad);
        Task<Sedes?> Borrar(Sedes? entidad);
    }
}
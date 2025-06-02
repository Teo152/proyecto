using Lib_dominio.Entidades;
namespace lib_presentaciones.Interfaces
{
    public interface IUsuariosPresentacion
    {
        Task<List<Usuarios>> Listar();
        Task<List<Usuarios>> PorNombreUsuario(Usuarios? entidad);
        Task<Usuarios?> Guardar(Usuarios? entidad);
        Task<Usuarios?> Modificar(Usuarios? entidad);
        Task<Usuarios?> Borrar(Usuarios? entidad);
    }
}
using Lib_dominio.Entidades;
namespace lib_presentaciones.Interfaces
{
    public interface IPersonasPresentacion
    {
        Task<List<Personas>> Listar();
        Task<List<Personas>> PorNombre(Personas? entidad);
        Task<Personas?> Guardar(Personas? entidad);
        Task<Personas?> Modificar(Personas? entidad);
        Task<Personas?> Borrar(Personas? entidad);
    }
}
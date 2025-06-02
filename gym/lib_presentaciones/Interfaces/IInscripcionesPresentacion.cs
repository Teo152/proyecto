using Lib_dominio.Entidades;
namespace lib_presentaciones.Interfaces
{
    public interface IInscripcionesPresentacion
    {
        Task<List<Inscripciones>> Listar();
        Task<List<Inscripciones>> PorCodigo(Inscripciones? entidad);
        Task<Inscripciones?> Guardar(Inscripciones? entidad);
        Task<Inscripciones?> Modificar(Inscripciones? entidad);
        Task<Inscripciones?> Borrar(Inscripciones? entidad);
    }
}
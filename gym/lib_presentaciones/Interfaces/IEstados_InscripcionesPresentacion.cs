using Lib_dominio.Entidades;
namespace lib_presentaciones.Interfaces
{
    public interface IEstados_InscripcionesPresentacion
    {
        Task<List<Estados_Inscripciones>> Listar();
        Task<List<Estados_Inscripciones>> PorEstado(Estados_Inscripciones? entidad);
        Task<Estados_Inscripciones?> Guardar(Estados_Inscripciones? entidad);
        Task<Estados_Inscripciones?> Modificar(Estados_Inscripciones? entidad);
        Task<Estados_Inscripciones?> Borrar(Estados_Inscripciones? entidad);
    }
}
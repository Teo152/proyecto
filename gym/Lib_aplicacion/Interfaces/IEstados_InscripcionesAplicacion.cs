
using Lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IEstados_InscripcionesAplicacion
    {
        void Configurar(string StringConexion);
        List<Estados_Inscripciones> PorCodigo(Estados_Inscripciones? entidad);
        List<Estados_Inscripciones> Listar();
        Estados_Inscripciones? Guardar(Estados_Inscripciones? entidad);
        Estados_Inscripciones? Modificar(Estados_Inscripciones? entidad);
        Estados_Inscripciones? Borrar(Estados_Inscripciones? entidad);
    }
}
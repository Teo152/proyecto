
using Lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IInscripcionesAplicacion
    {
        void Configurar(string StringConexion);
        List<Inscripciones> PorCodigo(Inscripciones? entidad);
        List<Inscripciones> Listar();
        Inscripciones? Guardar(Inscripciones? entidad);

        Inscripciones? Modificar(Inscripciones? entidad);
        Inscripciones? Borrar(Inscripciones? entidad);
    }
}
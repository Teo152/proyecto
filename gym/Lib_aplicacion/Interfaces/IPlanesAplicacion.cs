
using Lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IPlanesAplicacion
    {
        void Configurar(string StringConexion);
        List<Planes> PorCodigo(Planes? entidad);
        List<Planes> Listar();
        Planes? Guardar(Planes? entidad);
        Planes? Modificar(Planes? entidad);
        Planes? Borrar(Planes? entidad);
    }
}
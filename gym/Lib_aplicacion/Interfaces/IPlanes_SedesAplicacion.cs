
using Lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IPlanes_SedesAplicacion
    {
        void Configurar(string StringConexion);
        List<Planes_Sedes> PorCodigo(Planes_Sedes? entidad);
        List<Planes_Sedes> Listar();
        Planes_Sedes? Guardar(Planes_Sedes? entidad);

        Planes_Sedes? Modificar(Planes_Sedes? entidad);
        Planes_Sedes? Borrar(Planes_Sedes? entidad);
    }
}
﻿
using Lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IUsuariosAplicacion
    {
        void Configurar(string StringConexion);
        List<Usuarios> PorNombreUsuario(Usuarios? entidad);
        List<Usuarios> Listar();
        Usuarios? Guardar(Usuarios? entidad);
        Usuarios? Modificar(Usuarios? entidad);
        Usuarios? Borrar(Usuarios? entidad);
    }
}
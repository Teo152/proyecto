﻿using Lib_dominio.Entidades;
namespace lib_presentaciones.Interfaces
{
    public interface IEmpleadosPresentacion
    {
        Task<List<Empleados>> Listar();
        Task<List<Empleados>> PorNombre(Empleados? entidad);
        Task<Empleados?> Guardar(Empleados? entidad);
        Task<Empleados?> Modificar(Empleados? entidad);
        Task<Empleados?> Borrar(Empleados? entidad);
    }
}
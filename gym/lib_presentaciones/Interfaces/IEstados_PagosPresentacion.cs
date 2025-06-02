using Lib_dominio.Entidades;
namespace lib_presentaciones.Interfaces
{
    public interface IEstados_pagosPresentacion
    {
        Task<List<Estados_pagos>> Listar();
        Task<List<Estados_pagos>> PorEstado(Estados_pagos? entidad);
        Task<Estados_pagos?> Guardar(Estados_pagos? entidad);
        Task<Estados_pagos?> Modificar(Estados_pagos? entidad);
        Task<Estados_pagos?> Borrar(Estados_pagos? entidad);
    }
}
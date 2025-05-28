
using Lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IEstados_pagosAplicacion
    {
        void Configurar(string StringConexion);
        List<Estados_pagos> PorCodigo(Estados_pagos? entidad);
        List<Estados_pagos> Listar();
        Estados_pagos? Guardar(Estados_pagos? entidad);
        Estados_pagos? Modificar(Estados_pagos? entidad);
        Estados_pagos? Borrar(Estados_pagos? entidad);
    }
}
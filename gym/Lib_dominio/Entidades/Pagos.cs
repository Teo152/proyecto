using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Lib_dominio.Entidades
{
    public class Pagos
    {
     public int id {  get; set; }

     public string? codigo { get; set; }

     public int inscripciones { get; set; }

     public int estados_pagos {  get; set; }

     public decimal monto { get; set; }

     public DateTime? fecha_pago {  get; set; }

        [ForeignKey("estados_pagos")][JsonIgnore] public Estados_pagos? _estados_pagos { get; set; }
        [ForeignKey("inscripciones")][JsonIgnore] public Inscripciones? _inscripciones { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_dominio.Entidades
{
    public class Planes
    {

        [Key] public int id {get; set; }
          

            public decimal? precio { get; set; }

            public String? detalle { get; set; }

            public String? nombre { get; set; }

        

    }
}

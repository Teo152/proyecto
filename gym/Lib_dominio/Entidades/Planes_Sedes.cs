using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_dominio.Entidades
{
   public class Planes_Sedes
    {
        public int id {  get; set; }

        public int sedes { get; set; }

        public int planes { get; set; }

        public string? tipo_acceso { get; set; }

        [ForeignKey("sedes")] public Sedes? _sedes { get; set; }
        [ForeignKey("planes")] public Planes? _planes { get; set; }
    }
}

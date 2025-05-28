using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Lib_dominio.Entidades
{
    public class Personas
    {

        public int id { get; set; }
        public string? nombre { get; set; }

        public int cedula { get; set; }

        public int telefono { get; set; }
        public string? email { get; set; }

        public int? planes { get; set; }

        [ForeignKey("planes")][JsonIgnore] public Planes? _planes { get; set; }
    }
}

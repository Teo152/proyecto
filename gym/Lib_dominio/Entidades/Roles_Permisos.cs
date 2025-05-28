using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Lib_dominio.Entidades
{
    public  class Roles_Permisos
    {
        public int id { get; set; }

       public string? codigo { get; set; }

        public int rol { get; set; }

        public int permiso { get; set; }

        [ForeignKey("rol")][JsonIgnore] public Roles? _rol { get; set; }
        [ForeignKey("permiso")][JsonIgnore] public Permisos? _permiso { get; set; }
    }
}

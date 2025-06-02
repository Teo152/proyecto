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
    public class Usuarios
    {
        [Key] public int id { get; set; }
        public string? nombreUsuario { get; set; } 
        public string? Contrasena { get; set; } 
        public int Rol { get; set; }

        [ForeignKey("Rol")][JsonIgnore] public Roles? _Rol { get; set; }

        public static object FirstOrDefault(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}

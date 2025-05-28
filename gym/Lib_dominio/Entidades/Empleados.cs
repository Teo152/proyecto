using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json; //me toco agregar este using para poder poner jsonIgnore en la clave foranea


namespace Lib_dominio.Entidades
{
    public class Empleados
    {
        public int id {  get; set; }
        public int cedula {get; set; }

        public String? nombre { get; set; }


        public int sedes { get; set; }
        [ForeignKey("sedes")] [JsonIgnore] public Sedes? _sedes { get; set; } //agregro JsonIgnore para que al momento de ejecutar en el postman no me salga
                                                                              //un atributo "_sedes":null ya con eso lo arreglo y no me sale 
    }
}

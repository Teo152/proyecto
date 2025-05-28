using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Lib_dominio.Entidades
{
    public class Observaciones
    {
        public int id {  get; set; }

        public int inscripciones { get; set; }

        public string descripcion {  get; set; }

        [ForeignKey("inscripciones")][JsonIgnore] public Inscripciones? _inscripciones { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_dominio.Entidades
{
    public class Inscripciones
    {
        public int id {  get; set; }
        public int personas { get; set; }
        public int estados_inscripciones {  get; set; }
        public int? planes_sedes { get; set; }

        public DateTime?  fecha_inscripcion { get; set; }

        public DateTime? fecha_vencimiento {  get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_dominio.Entidades
{
    public class Auditoria
    {
        public int Id { get; set; }
        public int Usuario { get; set; }
        public DateTime FechaHora { get; set; }
        public string? Accion { get; set; }

        [ForeignKey("Usuario")] public Usuarios? _usuarios { get; set; }
    }
}

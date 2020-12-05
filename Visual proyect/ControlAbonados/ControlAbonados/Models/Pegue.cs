using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlAbonados.Models
{
    public class Pegue
    {
        [Key]
        [MaxLength(8)]
        public string CodPegue { get; set; }

        public int IdAbonado { get; set; }
        [ForeignKey("IdAbonado")]
        public Abonado Abonado { get; set; }

        public int IdTipoPegue { get; set; }
        [ForeignKey("IdTipoPegue")]
        public TipoPegue TipoPegue { get; set; }

        public int IdEstadoPegue { get; set; }
        [ForeignKey("IdEstadoPegue")]
        public EstadoPegue EstadoPegue { get; set; }

        public int IdBloque { get; set; }
        [ForeignKey("IdBloque")]
        public Bloque Bloque { get; set; }

        [MaxLength(3)]
        public string NumCasa { get; set; } 

    }
}

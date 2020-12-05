using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlAbonados.Models
{
    public class ControlPago
    {
        [Key]
        public int IdControlPago { get; set; }

        public string CodPegue { get; set; }
        [ForeignKey("CodPegue")]
        public Pegue Pegue { get; set; }


        public int IdMes { get; set; }
        [ForeignKey("IdMes")]
        public Mes Mes { get; set; }

        public bool EstaPagado { get; set; } = true;

        

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 
    
namespace ControlAbonados.Models
{
    public class FechaEstadoPegue
    {
        [Key]
        public int IdFechaEstadoPegue { get; set; }
        
        public int IdEstadoPegue { get; set; }

        public int IdMes { get; set; }

        public string CodPegue { get; set; }

        [Required]
        [MaxLength(4)]
        public string Año { get; set; }

        [ForeignKey("IdEstadoPegue")]
        public EstadoPegue estadoPegue { get; set; }

        [ForeignKey("IdMes")]
        public Mes mes { get; set; }

        [ForeignKey("CodPegue")]
        public Pegue pegue { get; set; }


    }
}

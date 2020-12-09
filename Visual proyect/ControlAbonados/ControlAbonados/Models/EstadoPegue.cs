using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlAbonados.Models
{
    public class EstadoPegue
    {
        [Key]
        public int IdEstadoPegue { get; set; }

        [Required]
        [Index(IsUnique =true)]
        [MaxLength(20)]
        public string NombreEstadoPegue { get; set; }
    }
}

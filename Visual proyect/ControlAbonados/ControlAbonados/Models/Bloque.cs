using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlAbonados.Models
{
    public class Bloque
    {
        [Key]
        public int IdBloque { get; set; }

        [Required]
        [Index(IsUnique =true)]
        [MaxLength(3)]
        public string NumeroBloque { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlAbonados.Models
{
    public class Abonado
    {
        [Key]
        public int IdAbonado { get; set; }

        [Index(IsUnique=true)]
        [MaxLength(15)]
        public string NumIdentidad { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombres { get; set; }

        [Required]
        [MaxLength(50)]
        public string Apellidos { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

    }
}

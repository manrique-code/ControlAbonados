using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlAbonados.Models
{
    public class Mes
    {
        [Key]
        public int IdMes { get; set; }

        [Index(IsUnique = true)]
        [MaxLength(10)]
        public string NombreMes { get; set; }
    }
}

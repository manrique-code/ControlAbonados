using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlAbonados.Models
{
    public class Año
    {
        [Key]
        public int IdAño { get; set; }

        [Index(IsUnique = true)]
        [MaxLength(4)]
        public string NumAño { get; set; }
    }
}

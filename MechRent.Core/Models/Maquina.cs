using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechRent.Core.Models
{
    public class Maquina
    {
        public int Id { get; set; }
        [Required]
        public string nombreMaquina { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public double precioHora { get; set; }
        [Required]
        public int frecuenciaMantenimiento { get; set; }

    }
}

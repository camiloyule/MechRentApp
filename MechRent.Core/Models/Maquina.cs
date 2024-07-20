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
        public string nombreMaquina { get; set; }
        [Required]
        public string description { get; set; }
        public double precioHora { get; set; }
        public int frecuenciaMantenimiento { get; set; }

    }
}

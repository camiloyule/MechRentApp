using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechRent.Core.Models
{
    public class Maquina
    {
        public int Id { get; set; }
        public string nombreMaquina { get; set; }
        public string description { get; set; }
        public double precioHora { get; set; }
        public int frecuenciaMantenimiento { get; set; }

    }
}

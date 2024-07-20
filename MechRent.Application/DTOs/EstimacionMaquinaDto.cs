using MechRent.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechRent.Application.DTOs
{
    public class EstimacionMaquinaDto
    {
        public int id { get; set; }

        public MaquinaDto maquina { get; set; }
        public int horas { get; set; }
    }
}

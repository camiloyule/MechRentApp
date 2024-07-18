using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechRent.Core.Models
{
    public class EstimacionMaquina
    {
        public int id { get; set; }
        public int obraId { get; set; }
        public ObraPublica obraPublica { get; set; }
        public int maquinaId { get; set; }
        public Maquina maquina { get; set; }
        public int horas { get; set; }

    }
}

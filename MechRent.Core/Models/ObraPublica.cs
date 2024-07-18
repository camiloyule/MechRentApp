using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechRent.Core.Models
{
    public class ObraPublica
    {
        public int Id { get; set; }
        public string nombreObra { get; set; }
        public string descripcion { get; set; }
        public string ciudad { get; set; }
        public string departamento { get; set; }
        public string direccion { get; set; }
        public List<EstimacionMaquina> estimacionMaquinas { get; set; }


    }
}

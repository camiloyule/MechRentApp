using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MechRent.Application.DTOs
{
    public class ObraPublicaDto
    {
        public int Id { get; set; }
        public string nombreObra { get; set; }
        public string descripcion { get; set; }
        public string ciudad { get; set; }
        public string departamento { get; set; }
        public string direccion { get; set; }
        public List<EstimacionMaquinaDto> estimacionMaquinas { get; set; }
    }
}

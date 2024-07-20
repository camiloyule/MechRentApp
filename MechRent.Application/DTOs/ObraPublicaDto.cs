﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MechRent.Application.DTOs
{
    public class ObraPublicaDto
    {
        public int Id { get; set; }
        [Required]
        public string nombreObra { get; set; }
        [Required]
        public string descripcion { get; set; }
        [Required]
        public string ciudad { get; set; }
        [Required]
        public string departamento { get; set; }
        [Required]
        public string direccion { get; set; }
        public List<EstimacionMaquinaDto> estimacionMaquinas { get; set; }
    }
}

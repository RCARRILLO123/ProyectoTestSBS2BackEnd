using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Application.DTOs.Entidad
{
    public class EntidadResponse
    {
        public int CodigoEntidad { get; set; }
        public string? DescripcionEntidad { get; set; }
        public string? FechaRegistro { get; set; }
        public string? EstadoEntidad { get; set; }
    }

}

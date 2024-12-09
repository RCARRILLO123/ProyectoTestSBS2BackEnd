using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Test.Application.DTOs.Entidad
{
    public class EntidadRequest
    {
        public int? Id { get; set; }
        public string? Descripcion { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Application.Enums
{
    public class Enums
    {
        public enum EstadoOperacion
        {

            [Description("ACTIVO")]
            EstadoActivo = 1,
            [Description("ELIMINADO")]
            EstadoEliminado = 0,
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroGastos.DTO
{
    public class RespuestaDTO : BaseDTO
    {
        public int CodigoRespuesta { get; set; }

        public object ContenidoRespuesta { get; set; }
    }
}

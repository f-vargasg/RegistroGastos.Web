using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroGastos.DTO
{
    public class ErrorDTO : BaseDTO
    {
        public int CodigoError { get; set; }

        public string MensajeError { get; set; }


    }
}

using RegistroGastos.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroGastos.Web.ViewModel
{
    public class MonedaVM
    {
        public List<MonedaDTO> ListadoMonedas { get; set; }
        public MonedaDTO Moneda { get; set; }


    }
}

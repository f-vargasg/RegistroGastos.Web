using System;
using System.Collections.Generic;

#nullable disable

namespace RegistrosGastos.Datos2.RegGastosModel
{
    public partial class MovimGasto
    {
        public int CodMovimN { get; set; }
        public int CodTipogastoN { get; set; }
        public int CodMonedaN { get; set; }
        public DateTime FecRegistro { get; set; }
        public string DesObserva { get; set; }
        public string DesReferencia { get; set; }
        public decimal? MtoMoneori { get; set; }
        public string UsuIngreso { get; set; }
        public DateTime FecIngreso { get; set; }

        public virtual Monedum CodMonedaNNavigation { get; set; }
        public virtual TipoGasto CodTipogastoNNavigation { get; set; }
    }
}

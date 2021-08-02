using System;
using System.Collections.Generic;

#nullable disable

namespace RegistrosGastos.Datos2.RegGastosModel
{
    public partial class TipoCambio
    {
        public int CodTipocambioN { get; set; }
        public DateTime FecTipocambio { get; set; }
        public int CodMoneoriN { get; set; }
        public int CodMonedestN { get; set; }
        public decimal? MtoTipocambio { get; set; }
        public string UsuIngreso { get; set; }
        public DateTime FecIngreso { get; set; }

        public virtual Monedum CodMonedestNNavigation { get; set; }
        public virtual Monedum CodMoneoriNNavigation { get; set; }
    }
}

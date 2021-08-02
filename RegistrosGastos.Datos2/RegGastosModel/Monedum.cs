using System;
using System.Collections.Generic;

#nullable disable

namespace RegistrosGastos.Datos2.RegGastosModel
{
    public partial class Monedum
    {
        public Monedum()
        {
            MovimGastos = new HashSet<MovimGasto>();
            TipoCambioCodMonedestNNavigations = new HashSet<TipoCambio>();
            TipoCambioCodMoneoriNNavigations = new HashSet<TipoCambio>();
        }

        public int CodMonedaN { get; set; }
        public string DesMoneda { get; set; }
        public string UsuIngreso { get; set; }
        public DateTime FecIngreso { get; set; }

        public virtual ICollection<MovimGasto> MovimGastos { get; set; }
        public virtual ICollection<TipoCambio> TipoCambioCodMonedestNNavigations { get; set; }
        public virtual ICollection<TipoCambio> TipoCambioCodMoneoriNNavigations { get; set; }
    }
}

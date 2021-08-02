using System;
using System.Collections.Generic;

#nullable disable

namespace RegistrosGastos.Datos2.RegGastosModel
{
    public partial class TipoGasto
    {
        public TipoGasto()
        {
            MovimGastos = new HashSet<MovimGasto>();
        }

        public int CodTipogastoN { get; set; }
        public string DesTipogasto { get; set; }
        public string UsuIngreso { get; set; }
        public DateTime FecIngreso { get; set; }

        public virtual ICollection<MovimGasto> MovimGastos { get; set; }
    }
}

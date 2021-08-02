using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroGastos.DTO
{
    public class MonedaDTO : BaseDTO   // BaseDTO  tiene la identidad
    {

        [MaxLength(50, ErrorMessage = "El campo de identificación del descripción no puede ser mayor a 50 caracteres")]
        [Display(Name = "Descripción de Moneda")]
        public string DesMoneda { get; set; }


        [MaxLength(80, ErrorMessage = "El campo de usuario que ingresó puede ser mayor a 80 caracteres")]
        public string UsuIngreso { get; set; }

        [Required(ErrorMessage = "No se puede guardar una moneda sino tiene fecha y hora de ingreso")]
        [Display(Name = "Fecha de Ingreso")]
        public DateTime FecIngreso { get; set; }

    }
}

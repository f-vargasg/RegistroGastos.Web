using RegistroGastos.DTO;
using RegistrosGastos.Datos2;
using RegistrosGastos.Datos2.RegGastosModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroGastos.Logica
{
    class MonedaLogica
    {
        #region Variables
        RegistroGastosDbContext contexto = new RegistroGastosDbContext();
        #endregion

        #region Constructor
        public MonedaLogica()
        {

        }
        #endregion


        #region Conversiones


        internal static MonedaDTO ConvertirDatosMonedaADTO(Monedum moneda)
        {
            return new MonedaDTO
            {
                IdEntidad = moneda.CodMonedaN,
                DesMoneda = moneda.DesMoneda,
                UsuIngreso = moneda.UsuIngreso,
                FecIngreso = moneda.FecIngreso
            };
        }


        internal static Monedum ConvertirDTOAMonedaDatos(MonedaDTO monedaDTO)
        {
            return new Monedum
            {
                DesMoneda = monedaDTO.DesMoneda,
                UsuIngreso = monedaDTO.UsuIngreso,
                FecIngreso = monedaDTO.FecIngreso
            };
        }
        #endregion

        #region Funciones
        public BaseDTO ObtenerMonedaPorCodigo (int codigo)
        {
            try
            {
                MonedaDatos intermedioEjemplo = new MonedaDatos();

                var respuestaDatos = intermedioEjemplo.ObtenerMonedaPorCodigo(codigo);
                // Caso Exitoso
                if (respuestaDatos.CodigoRespuesta == 1) // ok
                {
                    var monedaRespuesta = ConvertirDatosMonedaADTO((Monedum)respuestaDatos.ContenidoRespuesta);

                    return monedaRespuesta;
                }
                else
                {
                    // excepcion controlada
                    return (ErrorDTO)respuestaDatos.ContenidoRespuesta;
                }

            }
            catch (Exception error)
            {
                // excepciones no controladas
                return new ErrorDTO { MensajeError = error.Message };
            }
        }

        public List<BaseDTO> ListarTodasLasMonedas()
        {
            List<BaseDTO> respuesta = new List<BaseDTO>();

            try
            {
                MonedaDatos intermedioDatos = new MonedaDatos(this.contexto);

                var respuestaDatos = intermedioDatos.ListarTodasLasMonedas();
                if (respuestaDatos.CodigoRespuesta == 1)
                {
                    var lista = ((List<Monedum>)respuestaDatos.ContenidoRespuesta);
                    for (int i = 0; i < lista.Count; i++)
                    {
                        respuesta.Add(ConvertirDatosMonedaADTO(lista[i]));
                    }
                    return respuesta;
                }
                else
                {
                    respuesta.Clear();
                    respuesta.Add((ErrorDTO)respuestaDatos.ContenidoRespuesta);
                    return respuesta;
                }
            }
            catch (Exception error)
            {
                respuesta.Clear();
                respuesta.Add(new ErrorDTO { MensajeError = error.Message });
                return respuesta;
            }
        }

        #endregion

    }
}

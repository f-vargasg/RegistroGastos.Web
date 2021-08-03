using RegistroGastos.DTO;
using RegistrosGastos.Datos2.RegGastosModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrosGastos.Datos2
{
    public class MonedaDatos
    {
        #region Variables
        RegistroGastosDbContext contexto = new RegistroGastosDbContext();
        #endregion

        #region Constructores

        public MonedaDatos(RegistroGastosDbContext contextoGlobal)
        {
            contexto = contextoGlobal;
        }

        public MonedaDatos()
        {

        }
        #endregion

        #region Metodos

        public RespuestaDTO ObtenerMonedaPorCodigo (int codigo)
        {
            try
            {
                //                      1      2        3               4                    3*       
                // var producto = contexto.Productos.Where(P => P.PkProducto == codigo).FirstOrDefault();

                //                      1      2        3               4                    3*       
                var producto = contexto.Moneda.FirstOrDefault(P => P.CodMonedaN == codigo);
                if (producto != null)
                {
                    return new RespuestaDTO
                    {
                        CodigoRespuesta = 1,
                        ContenidoRespuesta = producto
                    };
                }
                else
                {
                    throw new Exception("No se encontraron Monedas con el código suministrato");
                }

            }
            catch (Exception error)
            {
                var excepcionalError = new Exception("Error Desconocido");
                if (error.InnerException != null)
                {
                    return new RespuestaDTO
                    {
                        CodigoRespuesta = -1,
                        ContenidoRespuesta = new ErrorDTO { MensajeError = excepcionalError.Message }
                    };
                }
                else
                {
                    return new RespuestaDTO
                    {
                        CodigoRespuesta = -1,
                        ContenidoRespuesta = new ErrorDTO { MensajeError = error.Message }
                    };
                }
            }
        }

        public RespuestaDTO ListarTodasLasMonedas()
        {
            try
            {
                //                 1       2         3
                var productos = contexto.Moneda.ToList();
                if (productos.Count > 0)
                {
                    return new RespuestaDTO
                    {
                        CodigoRespuesta = 1,
                        ContenidoRespuesta = productos
                    };
                }
                else
                {
                    throw new Exception("No se encontraron Monedas en la base de datos");
                }
            }
            catch (Exception error)
            {
                return new RespuestaDTO
                {
                    CodigoRespuesta = -1,
                    ContenidoRespuesta = new ErrorDTO { MensajeError = error.Message }
                };
            }
        }

        public RespuestaDTO AgregarMoneda(Monedum moneda)
        {
            try
            {
                contexto.Moneda.Add(moneda);
                var guardado = contexto.SaveChanges();
                if (guardado > 0)
                {
                    return new RespuestaDTO
                    {
                        CodigoRespuesta = 1,
                        ContenidoRespuesta = moneda.CodMonedaN,
                        Mensaje = "Los datos se guardaron correctamente"

                    };
                }
                else
                {
                    throw new Exception("No se pudo insertar el registro");
                }
            }
            catch (Exception error)
            {
                if (error.Message.Contains("ERROR controlado"))
                {
                    return new RespuestaDTO
                    {
                        CodigoRespuesta = -1,
                        ContenidoRespuesta = new ErrorDTO { MensajeError = error.Message }
                    };
                }
                else
                {
                    return new RespuestaDTO
                    {
                        CodigoRespuesta = -1,
                        ContenidoRespuesta = new ErrorDTO { MensajeError = "ERROR NO CONTROLADO" + error.InnerException }
                    };
                }
            }
        }

        public RespuestaDTO EliminarMoneda(Monedum moneda)
        {
            try
            {
                contexto.Moneda.Remove(moneda);

                if (contexto.SaveChanges() > 0)
                {
                    return new RespuestaDTO
                    {
                        CodigoRespuesta = 1,
                        ContenidoRespuesta = moneda
                    };
                }
                else
                {
                    throw new Exception("No se pudo eliminar el registro");
                }
            }
            catch (Exception error)
            {
                if (error.InnerException == null)
                {
                    return new RespuestaDTO
                    {
                        CodigoRespuesta = -1,
                        ContenidoRespuesta = new ErrorDTO { MensajeError = error.Message }
                    };
                }
                else
                {
                    return new RespuestaDTO
                    {
                        CodigoRespuesta = -1,
                        ContenidoRespuesta = new ErrorDTO { MensajeError = error.InnerException.Message }
                    };
                }
            }
        }

        public RespuestaDTO ModificarMoneda(MonedaDTO monedaDTO)
        {
            try
            {
                var moneda = contexto.Moneda.FirstOrDefault(C => C.CodMonedaN == monedaDTO.IdEntidad);
                if (moneda != null)
                {
                    moneda.DesMoneda = monedaDTO.DesMoneda;
                    if (contexto.SaveChanges() > 0)
                    {
                        return new RespuestaDTO
                        {
                            CodigoRespuesta = 1,
                            ContenidoRespuesta = moneda
                        };
                    }
                    else
                    {
                        throw new Exception("No se pudo actualizar los datos de la moneda");
                    }
                }
                else
                {
                    throw new Exception("No se encontró la moneda especificada");
                }
            }
            catch (Exception error)
            {
                if (error.InnerException != null)
                {
                    return new RespuestaDTO
                    {
                        CodigoRespuesta = -1,
                        ContenidoRespuesta = new ErrorDTO { MensajeError = error.InnerException.Message }
                    };
                }
                else
                {
                    return new RespuestaDTO
                    {
                        CodigoRespuesta = -1,
                        ContenidoRespuesta = new ErrorDTO { MensajeError = error.Message }
                    };
                }
            }
        }

        #endregion
    }
}

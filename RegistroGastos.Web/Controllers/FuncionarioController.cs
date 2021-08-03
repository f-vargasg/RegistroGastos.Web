using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistroGastos.DTO;
using RegistroGastos.Logica;
using RegistroGastos.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroGastos.Web.Controllers
{
    public class FuncionarioController : Controller
    {
        // GET: FuncionarioController
        public ActionResult Index()
        {
            return View();
        }

        // GET: FuncionarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FuncionarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FuncionarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FuncionarioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FuncionarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FuncionarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FuncionarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult ListarMonedas()
        {
            MonedaVM model = new MonedaVM();

            var resultado = new MonedaLogica().ListarTodasLasMonedas();

            if (resultado.ElementAt(0).GetType() == typeof(ErrorDTO))
            {
                model.Error = (ErrorDTO)resultado.ElementAt(0);
            }
            else
            {
                model.ListadoMonedas = new List<MonedaDTO>();
                foreach (var item in resultado)
                {
                    var itemConvertido = (MonedaDTO)item;
                    model.ListadoMonedas.Add(itemConvertido);
                }
            }
            return View(model);
        }

        public ActionResult CrearMoneda()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearMoneda(MonedaDTO model)
        {
            try
            {
                var resultado = new MonedaLogica().AgregarMoneda(model);


                if (resultado.GetType() == typeof(ErrorDTO))
                {
                    throw new Exception("Error");
                }
                else
                {
                    return RedirectToAction("DetalleMoneda", new { id = resultado.IdEntidad });
                    // return RedirectToAction(nameof(Index));
                }

            }
            catch
            {
                return View();
            }
        }

        public ActionResult DetalleMoneda(int id)
        {
            MonedaVM model = new MonedaVM();

            var resultado = new MonedaLogica().ObtenerMonedaPorCodigo(id);

            if (resultado.GetType() == typeof(ErrorDTO))
            {
                model.Error = (ErrorDTO)resultado;
            }
            else
            {
                model.Moneda = (MonedaDTO)resultado;
            }
            return View(model);
        }

        // Get
        public ActionResult EditarMoneda(int id)
        {
            MonedaVM model = new MonedaVM();

            var resultado = new MonedaLogica().ObtenerMonedaPorCodigo(id);

            if (resultado.GetType() == typeof(ErrorDTO))
            {
                model.Error = (ErrorDTO)resultado;
            }
            else
            {
                model.Moneda = (MonedaDTO)resultado;
            }
            return View(model.Moneda);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarMoneda(MonedaDTO model)
        {
            try
            {
                var resultado = new MonedaLogica().ModificarMoneda(model);


                if (resultado.GetType() == typeof(ErrorDTO))
                {
                    throw new Exception("Error");
                }
                else
                {
                    return RedirectToAction("DetalleMoneda", new { id = resultado.IdEntidad });
                }
            }
            catch
            {
                return View();
            }
        }
        
        
        public ActionResult EliminarMoneda(int id)
        {
            MonedaVM model = new MonedaVM();

            var resultado = new MonedaLogica().ObtenerMonedaPorCodigo(id);

            if (resultado.GetType() == typeof(ErrorDTO))
            {
                model.Error = (ErrorDTO)resultado;
            }
            else
            {
                model.Moneda = (MonedaDTO)resultado;
            }
            return View(model.Moneda);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarMoneda(MonedaDTO model)
        {

            var resultado = new MonedaLogica().EliminarMoneda(model);

            if (resultado.GetType() == typeof(ErrorDTO))
            {
                throw new Exception("Error");
            }
            else
            {
                return RedirectToAction("ListarMonedas");
            }

        }
    }
}

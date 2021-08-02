using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public ActionResult ListarMonedas ()
        {
            SucursalProductoVM model = new SucursalProductoVM();

            var resultado = new SucursalLogica().ListarTotalSucursales();

            if (resultado.ElementAt(0).GetType() == typeof(ErrorDTO))
            {
                model.Error = (ErrorDTO)resultado.ElementAt(0);
            }
            else
            {
                model.ListadoSucursales = new List<SucursalDTO>();
                foreach (var item in resultado)
                {
                    var itemConvertido = (SucursalDTO)item;
                    model.ListadoSucursales.Add(itemConvertido);
                }
            }
            return View(model);
        }

    }
}

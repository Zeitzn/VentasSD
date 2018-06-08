using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Distribuidos.VentasSD.Controllers
{
    public class CategoriasController : Controller
    {

        private readonly JavaService.WebServiceDCPClient java = new JavaService.WebServiceDCPClient();
        
        public ActionResult Index()
        {
            
            return View(java.CategoriaMostrarAll());
        }

    

        // GET: Categorias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        [HttpPost]
        public ActionResult Create(JavaService.categoria collection)
        {
            try
            {
                java.CategoriaRegistrar(collection.nombre,collection.descripcion);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categorias/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Categorias/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categorias/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Categorias/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

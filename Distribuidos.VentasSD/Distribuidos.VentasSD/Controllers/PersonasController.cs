using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Distribuidos.VentasSD.Controllers
{
    public class PersonasController : Controller
    {
        private readonly JavaService.WebServiceDCPClient java = new JavaService.WebServiceDCPClient();

        public ActionResult Index()
        {
            return View(java.PersonaMostrarAll());
        }

        // GET: Personas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Personas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personas/Create
        [HttpPost]
        public ActionResult Create(JavaService.persona model)
        {
            try
            {
                java.PersonaRegistrar(model.tipo_persona, model.nombre, model.papellido, model.sapellido, model.tipo_doc, model.num_doc, model.direccion, model.telefono, model.email);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Personas/Edit/5
        public ActionResult Edit(int id)
        {
            return View(java.PersonaBuscarById(id));
        }

        // POST: Personas/Edit/5
        [HttpPost]
        public ActionResult Edit(JavaService.persona model)
        {
            try
            {

                java.PersonaActualizar(model.idpersona, model.tipo_persona, model.nombre, model.papellido, model.sapellido, model.tipo_doc, model.num_doc, model.direccion, model.telefono, model.email);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Personas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Personas/Delete/5
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Distribuidos.VentasSD.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly JavaService.WebServiceDCPClient java = new JavaService.WebServiceDCPClient();
        // GET: Usuarios
        public ActionResult Index()
        {
            return View(java.UsuarioMostrarAll());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int id)
        {
            return View(java.UsuarioBuscarById(id));
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        public ActionResult Create(JavaService.usuario model)
        {
            try
            {
                java.UsuarioRegistrar(model.nombre, model.papellido, model.sapellido, model.tipo_doc, model.num_doc, model.direccion, model.telefono, model.email, model.cargo, model.login, model.pass, model.condicion);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int id)
        {
            return View(java.UsuarioBuscarById(id));
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        public ActionResult Edit(JavaService.usuario model)
        {
            try
            {
                if (model.pass==null)
                {
                    java.UsuarioActualizar(model.idusuario, model.nombre, model.papellido, model.sapellido, model.tipo_doc, model.num_doc, model.direccion, model.telefono, model.email, model.cargo, model.login, null, model.condicion);
                }
                else
                {
                    java.UsuarioActualizar(model.idusuario, model.nombre, model.papellido, model.sapellido, model.tipo_doc, model.num_doc, model.direccion, model.telefono, model.email, model.cargo, model.login, model.pass, model.condicion);
                }
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuarios/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

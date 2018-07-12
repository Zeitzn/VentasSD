using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Distribuidos.VentasSD.Controllers
{
    public class VentasController : Controller
    {
        private readonly JavaService.WebServiceDCPClient java = new JavaService.WebServiceDCPClient();
        // GET: Ventas
        public ActionResult Index()
        {
            return View(java.VentaUsuarioPersonaAll());
        }

        public JsonResult mostrar()
        {
            
            return Json(java.VentaUsuarioPersonaAll(), JsonRequestBehavior.AllowGet);
        }

        // GET: Ventas/Details/5
        public ActionResult Details(int id)
        {
            return View(java.DetventaBuscarByFk_idventa(id));
        }

        // GET: Ventas/Create
        public ActionResult Create()
        {
            ViewBag.ListPersonas = java.PersonaMostrarAll();
            ViewBag.ListUsuarios = java.UsuarioMostrarAll();
            return View();
        }

        // POST: Ventas/Create
        [HttpPost]
        public ActionResult Create(JavaService.venta model)
        {
            try
            {
                java.VentaRegistrar(model.fk_idcliente, model.fk_idusuario, model.tipo_comp, model.serie_comp, model.num_comp, (double)model.igv, (double)model.total);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ventas/Edit/5
        public ActionResult AsignarProducto(int id)
        {
            ViewBag.Productos = java.ProductoMostrarAll();
            //ViewBag.Venta = java.VentaBuscarById(id);

            return View(java.VentaBuscarById(id));
        }

        // POST: Ventas/Edit/5
        [HttpPost]
        public ActionResult AsignarProducto(int idventa, int idproducto,double precio,int cantidad,double descuento)
        {
            try
            {

                java.DetventaRegistrar(idproducto, idventa, cantidad, precio, descuento);
               
                return RedirectToAction("Index");

            }
            catch
            {
                return View();

            }
        }

        // GET: Ventas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ventas/Delete/5
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

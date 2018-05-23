using Distribuidos.VentasSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Distribuidos.VentasSD.Controllers
{
    public class HomeController : Controller
    {
        private readonly JavaService.WebServiceDCPClient java = new JavaService.WebServiceDCPClient();
        // GET: Home
        public ActionResult Index()
        {
            CategoriaViewModel cat = new CategoriaViewModel()
            {
                ListaCategoria = java.CategoriaMostrarAll().ToList()
            };
            return View(cat);
        }
    }
}
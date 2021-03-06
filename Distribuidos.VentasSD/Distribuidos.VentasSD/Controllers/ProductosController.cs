﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Distribuidos.VentasSD.Controllers
{
    public class ProductosController : Controller
    {
        private readonly JavaService.WebServiceDCPClient java = new JavaService.WebServiceDCPClient();

        public ActionResult Index()
        {
            
            return View(java.ProductoMostrarAll());
        }

        

        // GET: Productos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            ViewBag.Categorias = new SelectList(java.CategoriaMostrarAll(), "id", "nombre");
            return View();
        }

        // POST: Productos/Create
        [HttpPost]
        public ActionResult Create(JavaService.producto model)
        {
            try
            {

                java.ProductoRegistrar(model.fk_idcategoria, model.codigo, model.nombre, model.descripcion, model.stock, model.condicion);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int id)
        {
            
            return View(java.ProductoBuscarById(id));
        }

        // POST: Productos/Edit/5
        [HttpPost]
        public ActionResult Edit(JavaService.producto model)
        {
            try
            {
                java.ProductoActualizar(model.idproducto, model.fk_idcategoria, model.codigo, model.nombre, model.descripcion, model.stock, model.condicion);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Productos/Delete/5
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

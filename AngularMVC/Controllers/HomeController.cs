﻿using ServiceLayer;
using ViewModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularMVC.Controllers
{
    public class HomeController : Controller
    {
        Logic service = new Logic();
        
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetProducts()
        {
            return Json(service.listProducts(), JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public ActionResult Create(ProductModel product)
        {
            service.addProduct(product);
            return RedirectToAction("Index");
        }

        
        public ActionResult Delete(int id)
        {
            service.removeProduct(id);
            return RedirectToAction("Index");
        }

        public JsonResult Edit(int id)
        {
            return Json(service.getProduct(id), JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public ActionResult Edit(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                service.editProduct(product);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}
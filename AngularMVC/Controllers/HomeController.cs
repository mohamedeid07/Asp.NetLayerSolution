using ServiceLayer;
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


        public ActionResult Create()
        {
            return View();
        }
        
        //[HttpPost]
        //public ActionResult Create(ProductModel product)
        //{
            
        //        service.addProduct(product.ID,product.Name,product.NumberOfDays);
        //        return RedirectToAction("Index");
            
        //    return View();
        //}
        [HttpPost]
        public ActionResult Create(ProductModel product)
        {

            service.addProduct( product.Name, product.NumberOfDays);
            return RedirectToAction("Index");
        }

        
        public ActionResult Delete(int id)
        {
            service.removeProduct(id);
            return RedirectToAction("Index");
        }
        
        //public ActionResult Edit(int id)
        //{
        //    var product = service.getProduct(id);
        //    ProductModel productModel = new ProductModel
        //    {
        //        ID = product.ID,
        //        Name = product.Name,
        //        NumberOfDays = (int)product.NumberOfDays
        //    };

        //    return View(productModel);
        //}

        public JsonResult Edit(int id)
        {
            return Json(service.getProduct(id), JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public ActionResult Edit(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                service.editProduct(product.ID, product.Name, product.NumberOfDays);
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
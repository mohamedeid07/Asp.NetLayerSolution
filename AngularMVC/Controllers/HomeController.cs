using ServiceLayer;
using ViewModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Reporting.WebForms;

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
        /*
        public ActionResult Report()
        {
            LocalReport report = new LocalReport();
            report.ReportPath = Server.MapPath("~/Reports/ProductsReport.rdlc");

            ReportDataSource datasrc = new ReportDataSource();
            datasrc.Name = "ProductsDataSource";
            datasrc.Value = service.listProducts();
            report.DataSources.Add(datasrc);
            string reportType= "PDF";
            string mimeType;
            string encoding;
            string fileNameExtension = ".pdf";

            string[] streams;
            Warning[] warnings;
            byte[] renderedByte = report.Render(reportType,"",out mimeType, out encoding,
                out fileNameExtension, out streams, out warnings);

            Response.AddHeader("content:dispostion", "attatchment:filename= products_report.pdf");
            return File(renderedByte,fileNameExtension);
        }
        */
    }
}
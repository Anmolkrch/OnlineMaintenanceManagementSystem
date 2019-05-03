using Quiz.ViewModel;
using Quiz.Service.ProductMaintenanceService;
using Quiz.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Quiz.Service.ProductService;

namespace QuizApplicationMVC5.Controllers
{
    public class ProductMaintenanceController : Controller
    {
        // GET: Product
        IProductMaintenanceService _IProductMaintenanceService = new ProductMaintenanceService();
        IProductService _IProductService = new ProductService();
        // GET: /serviceRequest/
        public ActionResult Index()
        {
           
            return View(_IProductMaintenanceService.ProductMaintenanceList());
        }

        // GET: /serviceRequest/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ProductMaintenanceService = _IProductMaintenanceService.ProductMaintenanceRequest(id);
            if (ProductMaintenanceService == null)
            {
                return HttpNotFound();
            }
            return View(ProductMaintenanceService);
        }

        // GET: /serviceRequest/Edit/5
        public ActionResult Edit(int? id)
        {
            dynamic ProductMaintenanceService = new ProductMaintenanceViewModel();
            if (id != null && id != 0)
            {
                ProductMaintenanceService = _IProductMaintenanceService.ProductMaintenanceRequest(id);
            }
            ViewBag.Products = _IProductService.ProductList();
            return View(ProductMaintenanceService);
        }

        // POST: /serviceRequest/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductMaintenanceViewModel ProductMaintenanceService)
        {
            if (ModelState.IsValid)
            {
                _IProductMaintenanceService.SaveProductMaintenanceRequests(ProductMaintenanceService);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "The ProductId  is required");
                // ViewBag.ErrorMsg = "Please check your username and password! ";
            }
            ViewBag.Products = _IProductService.ProductList();
            return View(ProductMaintenanceService);
        }

        // GET: /serviceRequest/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductMaintenanceViewModel ProductService = _IProductMaintenanceService.ProductMaintenanceRequest(id);
            if (ProductService == null)
            {
                return HttpNotFound();
            }
            return View(ProductService);
        }

        // POST: /serviceRequest/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _IProductMaintenanceService.DeleteProductMaintenanceRequest(id);

            return RedirectToAction("Index");
        }
    }
}
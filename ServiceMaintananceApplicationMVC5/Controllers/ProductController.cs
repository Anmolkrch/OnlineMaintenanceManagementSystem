using ServiceMaintanance.Service.ProductService;
using ServiceMaintanance.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ServiceMaintananceApplicationMVC5.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        IProductService _IProductService = new ProductService();
        // GET: /serviceRequest/
        public ActionResult Index()
        {
            return View(_IProductService.ProductList());
        }

        // GET: /serviceRequest/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ProductService = _IProductService.ProductRequest(id);
            if (ProductService == null)
            {
                return HttpNotFound();
            }
            return View(ProductService);
        }

        // GET: /serviceRequest/Edit/5
        public ActionResult Edit(int? id)
        {
            dynamic ProductService = new ProductViewModel();
            if (id != null && id != 0)
            {
                ProductService = _IProductService.ProductRequest(id);
            }
            return View(ProductService);
        }

        // POST: /serviceRequest/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductViewModel ProductService)
        {
            if (ModelState.IsValid)
            {
                _IProductService.SaveProductRequests(ProductService);
                return RedirectToAction("Index");
            }
            return View(ProductService);
        }

        // GET: /serviceRequest/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductViewModel ProductService = _IProductService.ProductRequest(id);
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
            _IProductService.DeleteProductRequest(id);

            return RedirectToAction("Index");
        }
    }
}
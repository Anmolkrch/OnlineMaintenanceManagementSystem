using Quiz.Service.ServiceRequest;
using Quiz.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace MVCFinalProject.Controllers
{
    public class ServiceRequestController : Controller
    {
        IServiceRequestService _IServiceRequest = new ServiceRequestService();

        // GET: /serviceRequest/
        public ActionResult Index()
        {
            return View(_IServiceRequest.ServiceRequestsList());
        }

        // GET: /serviceRequest/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var serviceRequest = _IServiceRequest.serviceRequest(id);
            if (serviceRequest == null)
            {
                return HttpNotFound();
            }
            return View(serviceRequest);
        }

        // GET: /serviceRequest/Edit/5
        public ActionResult Edit(int? id)
        {
            dynamic serviceRequest = new ServiceRequestViewModel();
            if (id != null && id != 0)
            {
                serviceRequest = _IServiceRequest.serviceRequest(id);
            }
            return View(serviceRequest);
        }

        // POST: /serviceRequest/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ServiceRequestViewModel serviceRequest)
        {
            if (ModelState.IsValid)
            {
                _IServiceRequest.SaveServiceRequestsStatus(serviceRequest);
                return RedirectToAction("Index");
            }
            return View(serviceRequest);
        }

        // GET: /serviceRequest/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceRequestViewModel serviceRequest = _IServiceRequest.serviceRequest(id);
            if (serviceRequest == null)
            {
                return HttpNotFound();
            }
            return View(serviceRequest);
        }

        // POST: /serviceRequest/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _IServiceRequest.DeleteserviceRequest(id);

            return RedirectToAction("Index");
        }
        public ActionResult UserIndex(int UserId)
        {
            return View(_IServiceRequest.ServiceRequestsList().Where(x=>x.UserId== UserId));
        }
    }
}

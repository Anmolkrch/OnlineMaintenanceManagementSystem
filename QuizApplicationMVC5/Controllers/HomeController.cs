using Quiz.Service.Master;
using Quiz.Service.ServiceRequest;
using Quiz.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizApplicationMVC5.Controllers
{
    public class HomeController : Controller
    {
        IServiceRequestService _IServiceRequestService = new ServiceRequestService();
        IMasterService _IMasterService = new MasterService();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult ServiceRequest(string Product)
        {
            ServiceRequestViewModel ObjServiceRequestViewModel = new ServiceRequestViewModel();
            ViewBag.Visibility = "none";
            ObjServiceRequestViewModel.ProductTybe = Product;
            return View(ObjServiceRequestViewModel);
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ServiceRequest(ServiceRequestViewModel model, string returnUrl)
        {
            string mailBody = string.Empty;
            if (ModelState.IsValid)
            {
                
                try
                {
                    _IServiceRequestService.SaveServiceRequests(model);
                    UserViewModel user = new UserViewModel();
                    user.Email = model.Email;
                    user.FirstName = model.FirsName;
                    mailBody = RenderPartialToString("_Notify", user, ControllerContext);
                    _IMasterService.SendAccountCreatationEmail("Service Request Generated", mailBody, user, 101);
                    
                }
               
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Invalid login attempt");
                    return View(model);
                }

            }
            ModelState.Clear();
            ViewBag.Message = "Thanks " +  model.FirsName + "" + "  your request is created for "+model.ProductTybe;
            ViewBag.Visibility = "inline";
            model = new ServiceRequestViewModel();
            return View(model);
        }
        public static string RenderPartialToString(string viewName, object model, ControllerContext ControllerContext)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.RouteData.GetRequiredString("action");


            viewName = "~/Views/Shared/Email Templates/" + viewName + ".cshtml";
            ViewDataDictionary ViewData = new ViewDataDictionary();
            TempDataDictionary TempData = new TempDataDictionary();
            ViewData.Model = model;

            using (StringWriter sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }

    }
}
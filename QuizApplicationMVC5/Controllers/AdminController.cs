
using LinqToExcel;
using Quiz.Utility;
using Quiz.Utility.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRMS.Controllers
{
    [CustomAuthorize]
    [RoleAuthorize(AppConstant.RoleAdmin)]
    public class AdminController : Controller
    {
        // GET: Admin
      
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MyProfile()
        {
            return View();
        }
        
        public ActionResult UploadExcel()
        {
            ViewBag.Error = TempData["UploadExcel"] as string;
            return View();
        }
    }
}
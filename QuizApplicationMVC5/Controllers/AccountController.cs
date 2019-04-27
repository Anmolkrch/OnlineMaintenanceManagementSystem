using Newtonsoft.Json;
using Quiz.Model.Master;
using Quiz.Service.UserService;
using Quiz.Utility.Helper;
using Quiz.ViewModel;
using System;
using System.Collections;
using System.Web.Mvc;


namespace QuizApplicationMVC5.Controllers
{
    [HandleError]
    public class AccountController : Controller
    {

        IUserService _IUserService = new UserService();

        //public AccountController()
        //{
        //}

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            try
            {
                var jsonData = SecurityHelper.Decrypt(HttpContext.Request.Cookies["ES"]["US"].ToString());
                Hashtable decryptedData = JsonConvert.DeserializeObject<Hashtable>(jsonData);
                UserService _IUserService = new UserService();

                var user = _IUserService.GetUsersDetailsById(Convert.ToInt64(decryptedData["LogId"]));
                if (user.Id!=0)
                {
                    Session["UserConnected"] = user;
                    if (decryptedData["Role"].ToString() == "student")
                        return RedirectToAction("SelectQuizz", "Quizz");
                    else
                        return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return View();
                }

            }
           catch (Exception ex)
            {
                return View();
            }
            
            
            //if (TempData["result"] != null)
            //{
            //    var myJsonResult = TempData["result"] as MyJsonResult;
            //    if (myJsonResult.data != null)
            //        return View(new LoginViewModel { Email = myJsonResult.data.ToString() });
            //}
          //  return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.PasswordHash = SecurityHelper.CreatePasswordHash(model.Password, "");

                    UserViewModel authenticatedUser = null;
                    authenticatedUser = _IUserService.LoginAuthentication(model);
                   
                    if (authenticatedUser != null)
                    {
                        string rememberme = (model.RememberMe) ? "true" : "false";
                        UserAuthenticate.AddLoginCookie(authenticatedUser.FirstName + " " +
                            authenticatedUser.LastName, authenticatedUser.UserTypeCode, authenticatedUser.Id.ToString(),
                                     authenticatedUser.UserTypeName, rememberme);
                        if(authenticatedUser.UserTypeId==1)
                        {
                            Session["UserConnected"] = authenticatedUser;
                            return RedirectToAction("Index", "Admin");
                        }
                        else
                        {
                            Session["UserConnected"] = authenticatedUser;
                            return RedirectToAction("SelectQuizz", "Quizz");
                        }

                    }
                    else
                    {
                        ModelState.AddModelError("", "User Not Authenticated ");
                        // ViewBag.ErrorMsg = "Please check your username and password! ";
                    }
                }
                catch (CustomException customException)
                {
                    ModelState.AddModelError("", customException.Message);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Invalid login attempt");
                }

            }
            return View(model);
        }
        
        public ActionResult LogOff()
        {
            TempData.Keep("result");

            //if (UserAuthenticate.IsAuthenticated)
            //    _userService.UserLogOff(UserAuthenticate.LogId);
            UserAuthenticate.Logout(System.Web.HttpContext.Current);
            return RedirectToAction("Login", "Account");
        }

        public ActionResult Unauthorized()
        {
            UserAuthenticate.Logout(System.Web.HttpContext.Current);
            return View();
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

       
    }
}
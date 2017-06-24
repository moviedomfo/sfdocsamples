using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CustomSecurity.BE;
using CustomSecurity.CustomAuthClass;
using CustomSecurity.DAC;
using CustomSecurity.Models;

namespace CustomSecurity.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult LogIn()
        {
            bool j = User.Identity.IsAuthenticated;

            return View();
        }
        [HttpPost]

        public ActionResult LogIn(LogOnModel model, string returnUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Some code to validate and check authentication
                    if (!UsersDAC.ValidateUser(model.UserName, model.Password))
                        throw new Exception("Incorrect username or password");

                    UserData account = UsersDAC.Get(model.UserName);


                    HttpResponseBaseExtensions.SetAuthCookie<UserData>(Response, account.Id.ToString(), model.RememberMe, account);
                    //Response.SetAuthCookie(account.Id.ToString(), model.RememberMe, account);
                   

                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            model.Password = "";
            return View(model);
        }

        [CustomAuthenticationAttribute(OuthRuleName = "admin")]
        public ActionResult Index( )
        {
            return View();
        }

    }
}

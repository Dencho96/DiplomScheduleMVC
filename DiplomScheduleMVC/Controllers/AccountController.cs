using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DiplomScheduleMVC.Controllers
{
    public class AccountController : Controller
    {

        public AccountController()
        {
        }

        #region Login

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(string username, string password)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (username == "admin"&&password=="123")
            {
                var identity = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, username),
                    },
                    "ApplicationCookie");

                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;

                authManager.SignIn(identity);

                return Redirect("/Home/AdminPanel");
            }
            else
            {
                ViewBag.InvalidParameters = "Check";
                return View();
            }

            //ModelState.AddModelError("", "Invalid username or password");
            //return View();
        }

        #endregion


        public ActionResult LogOut()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("index", "home");
        }

        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("index", "home");
            }
            return returnUrl;
        }
    }

}
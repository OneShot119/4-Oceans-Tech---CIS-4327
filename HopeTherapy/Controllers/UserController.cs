using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HopeTherapy.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Login(Models.User user)
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    if (user.IsValid(user.UserName, user.Password))
                    {
                        FormsAuthentication.SetAuthCookie(user.UserName, user.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Login data is incorrect!");
                    }
                }
                return View(user);
            }
        }

        public ActionResult Logout()
        {
                FormsAuthentication.SignOut();
                return RedirectToAction("Index", "Home");
        }
    }
}
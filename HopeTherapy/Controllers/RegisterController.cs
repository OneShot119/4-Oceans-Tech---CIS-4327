using HopeTherapy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HopeTherapy.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Register model)
        {
            if (!ModelState.IsValid)
            {
                // Todo: Model is not valid.
                return View(model);
            }

            // Todo: Check database
            var user = new User();
            user.UserName = model.Username;
            user.Password = model.Password;
            FormsAuthentication.SetAuthCookie(user.UserName, true);
            return RedirectToAction("Index","Home");
        }
    }
}
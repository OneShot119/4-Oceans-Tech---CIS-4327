using HopeTherapy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return View(model);
        }
    }
}
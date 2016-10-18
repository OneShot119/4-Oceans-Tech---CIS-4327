using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HopeTherapy.Models;
using System.Web.Mvc;

namespace HopeTherapy.Controllers
{
    public class DonorController : Controller
    {
        // GET: Donor
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Donor model)
        {

            // Todo: Check database
            return View(model);
        }
    }
}

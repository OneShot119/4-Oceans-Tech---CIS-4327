using HopeTherapy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HopeTherapy.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        public ActionResult Index()
        {
            var model = Utilities.Sql.ExecuteQuery<Login>("SELECT * FROM dbo.[Login]");
            return View(model);
        }
    }
}
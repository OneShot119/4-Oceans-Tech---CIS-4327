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
        [HttpGet]
        public ActionResult Index()
        {
            return View(new Login());


//            Utilities.Sql.ExecuteCommand(@"
//INSERT INTO dbo.[Login]
//(
//Username,
//Password
//)
//VALUES
//(
//	@Username,
//    @Password
//)", new { Username = "garbage", Password = "null"});
//            var model = Utilities.Sql.ExecuteQuery<Login>("SELECT * FROM dbo.[Login] WHERE Username = @Username", new { Username = "garbage" });
//            return View(model);
        }

        [HttpPost]
        public ActionResult Index(Login model)
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
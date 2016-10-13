using HopeTherapy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using HopeTherapy.DataAccess;
using System.Data.SqlClient;
using System.Configuration;

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
            //string sql = "INSERT INTO Register VALUES("+model.Username+ ", " + model.Password + ")";
            //int temp = DataAccess.SqlDataAccess.ExecuteCommand(sql);
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["HopeTherapyIMS"].ConnectionString))
            {
                string sql = "INSERT INTO [UserName, Password, Email, FirstName, LastName] FROM [dbo].[Register] VALUES[" + model.Username + ", " + model.Password + ", " + model.Email + ", " + model.FirstName + ", " + model.LastName + "]";
                //Todo: Not working
                //int temp = SqlDataAccess.ExecuteCommand(sql, null);
            }

                var user = new User();
            user.UserName = model.Username;
            user.Password = model.Password;
            FormsAuthentication.SetAuthCookie(user.UserName, true);
            return RedirectToAction("Index","Home");
        }
    }
}
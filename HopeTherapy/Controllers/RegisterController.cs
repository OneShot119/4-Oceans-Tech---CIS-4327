﻿using HopeTherapy.Models;
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

        [HttpPost] [ValidateAntiForgeryToken]
        public ActionResult Index(Register model)
        {
            if (!ModelState.IsValid)
            {
                // Todo: Model is not valid.
                return View(model);
            }

            var regCode = ConfigurationManager.AppSettings["RegCode"];
            if (!string.Equals(model.AccessKey, regCode))
            {
                ModelState.AddModelError("AccessKey", "Incorrect AccessKey.");
                return View(model);
            }

            // Todo: Check database
            //string sql = "INSERT INTO Register VALUES("+model.Username+ ", " + model.Password + ")";
            //int temp = DataAccess.SqlDataAccess.ExecuteCommand(sql);
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["HopeTherapyIMS"].ConnectionString))
            {
                string sql = "INSERT INTO [dbo].[Register] (UserName, Password, Email, FirstName, LastName)  VALUES(@Username, @Password, @Email, @FirstName, @LastName)";
                Utilities.Sql.ExecuteCommand(sql, model);
            }

                var user = new User();
            user.UserName = model.Username;
            user.Password = model.Password;
            FormsAuthentication.SetAuthCookie(user.UserName, true);
            return RedirectToAction("Index","Home");
        }
    }
}
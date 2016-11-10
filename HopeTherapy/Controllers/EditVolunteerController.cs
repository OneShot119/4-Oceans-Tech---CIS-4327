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
    public class EditVolunteerController : Controller
    {
        // GET: EditVolunteer
        public ActionResult Index()
        {
            return View();
        }
             public ActionResult Index(Volunteer model)
        { 
            using (var cn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["HopeTherapyIMS"].ConnectionString))

            {
                string sql = "INSERT INTO [dbo].[Volunteer] (FirstName, LastName, Salutation, StreetAddress, City, States, ZipCode, County, CellPhoneNumber, HomePhoneNumber, WorkPhoneNumber, Email, Birthday, Gender, Job, DateOrientation, DateStarted, DaysVolunteered, HoursPerMonth)  VALUES(@FirstName, @LastName, @Salutation, @StreetAddress, @City, @States, @ZipCode, @County, @CellPhoneNumber, @HomePhoneNumber, @WorkPhoneNumber, @Email, @Birthday, @Gender, @Job, @DateOrientation, @DateStarted, @DaysVolunteered, @HoursPerMonth)";
                try
                {
                    Utilities.Sql.ExecuteCommand(sql, model);
                }
                catch (SqlException)
                {
                    /*if(ex.Number == 2627) // 2627 = unique constraint violation.
                    {
                        ModelState.AddModelError("VolunteerID", "Volunteer is already in the system.");
                        return View(model);
                    }*/
                    throw;
                }

            }
            var Volunteer = new Volunteer();

            return RedirectToAction("Index", "Home");
        }
    }
    
}
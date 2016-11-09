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
    public class VolunteerController : Controller
    {
        // GET: Volunteer
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Volunteer model)
        {
            // Todo: Check database
            return View(model);
        
                    using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["HopeTherapyIMS"].ConnectionString))
            {
                string sql = "INSERT INTO [dbo].[Volunteer] (VolunteerID, FirstName, LastName, Salutation, StreetAddress, City, States, ZipCode, County, CellPhoneNumber, HomePhoneNumber, OfficePhoneNumber, Email, Birthday, Gender, Job, DateOrientation, DateStarted, DaysVolunteered, HoursPerMonth)  VALUES(@VolunteerID, @FirstName, @LastName, @Salutation, @StreetAddress, @City, @States, @ZipCode, @County, @CellPhoneNumber, @HomePhoneNumber, @OfficePhoneNumber, @Email, @Birthday, @Gender, @Job, @DateOrientation, @DateStarted, @DaysVolunteered, @HoursPerMonth)";
                try
                {
                    Utilities.Sql.ExecuteCommand(sql, model);
                }
                catch (SqlException ex)
                {
                    if(ex.Number == 2627) // 2627 = unique constraint violation.
                    {
                        ModelState.AddModelError("VolunteerID", "Volunteer is already in the system.");
                        return View(model);
                    }
                    throw;
                }
              var volunteer = new Volunteer();
            }
        }
    }
}
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
            


            using (var cn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["HopeTherapyIMS"].ConnectionString))

            {
                string sql = "INSERT INTO [dbo].[Volunteer] (FirstName, LastName, Salutation, StreetAddress, City, States, ZipCode, County, CellPhoneNumber, HomePhoneNumber, WorkPhoneNumber, Email, Birthday, Gender, Job, DateOrientation, DateStarted, DaysVolunteered, HoursPerMonth, CompanyName, Position, CompanyAddress, VolunteerPosition, AreaOfInterest, Skills, Donor, Board, EmailList, MailList)  VALUES(@FirstName, @LastName, @Salutation, @StreetAddress, @City, @States, @ZipCode, @County, @CellPhoneNumber, @HomePhoneNumber, @WorkPhoneNumber, @Email, @Birthday, @Gender, @Job, @DateOrientation, @DateStarted, @DaysVolunteered, @HoursPerMonth, @CompanyName, @Position, @CompanyAddress, @VolunteerPosition, @AreaOfInterest, @Skills, @Donor, @Board, @EmailList, @MailList)";
                try
                {
                    Utilities.Sql.ExecuteCommand(sql, model);
                }
                catch (SqlException ex)
                {
                    throw;
                }
             
            }
            var Volunteer = new Volunteer();
            
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult List()
        {
            var Volunteers = Utilities.Sql.ExecuteQuery<Volunteer>("select FirstName as FirstName, LastName as LastName, Email as Email, DaysVolunteered as DaysVolunteered, HoursPerMonth as HoursPerMonth from dbo.Volunteer;");
            return View(Volunteers);

        }
    }
}
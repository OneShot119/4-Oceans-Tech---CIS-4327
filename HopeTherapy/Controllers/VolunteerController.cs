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

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var Volunteers = Utilities.Sql.ExecuteQuerySingleResult<Volunteer>("select * from dbo.Volunteer WHERE Volunteer.VolunteerID = " +ID+";");
            return View(Volunteers);
        }

        [HttpPost]
        public ActionResult EditVolunteer(Volunteer model)
        {
            // Todo: Check database



            using (var cn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["HopeTherapyIMS"].ConnectionString))

            {
                string sql = "UPDATE [dbo].[Volunteer] SET FirstName=@FirstName, LastName=@LastName, StreetAddress=@StreetAddress, City=@City, States=@States, ZipCode=@ZipCode, County=@County," +
                    "CellPhoneNumber=@CellPhoneNumber, HomePhoneNumber=@HomePhoneNumber, WorkPhoneNumber=@WorkPhoneNumber, Email=@Email, Birthday=@Birthday, Gender=@Gender, Job=@Job, DateOrientation=@DateOrientation, DateStarted=@DateStarted, " +
                    "HoursPerMonth=@HoursPerMonth, CompanyName=@CompanyName, Position=@Position, CompanyAddress=@CompanyAddress, VolunteerPosition=@VolunteerPosition, AreaOfInterest=@AreaOfInterest, Skills=@Skills, Donor=@Donor, Board=@Board, EmailList=@EmailList, MailList=@MailList " +
                    "WHERE VolunteerID = @VolunteerID;";
                try
                {
                    Utilities.Sql.ExecuteCommand(sql, model);
                }
                catch (SqlException ex)
                {
                    throw;
                }

            }

            return RedirectToAction("List", "Volunteer");
        }

        [HttpPost]
        public ActionResult Index(Volunteer model)
        {
            // Todo: Check database



            using (var cn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["HopeTherapyIMS"].ConnectionString))

            {
                string sql = "INSERT INTO [dbo].[Volunteer] (FirstName, LastName, StreetAddress, City, States, ZipCode, County," +
                    "CellPhoneNumber, HomePhoneNumber, WorkPhoneNumber, Email, Birthday, Gender, Job, DateOrientation, DateStarted, " +
                    "HoursPerMonth, CompanyName, Position, CompanyAddress, VolunteerPosition, AreaOfInterest, Skills, Donor, Board, EmailList, MailList)" +
                    "VALUES(@FirstName, @LastName, @StreetAddress, @City, @States, @ZipCode, @County, @CellPhoneNumber, @HomePhoneNumber," +
                    "@WorkPhoneNumber, @Email, @Birthday, @Gender, @Job, @DateOrientation, @DateStarted,  @HoursPerMonth, @CompanyName," +
                    "@Position, @CompanyAddress, @VolunteerPosition, @AreaOfInterest, @Skills, @Donor, @Board, @EmailList, @MailList)";
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
     /*   [HttpGet]
        public ActionResult Search(string LastName)
        {
            var Volunteers = Utilities.Sql.ExecuteQuerySingleResult<Volunteer>("SELECT * from dbo.Volunteer WHERE Volunteer.LastName = " + LastName + ";");
            return View(Volunteers);
        }

        [HttpPost]
    /*    public ActionResult SearchVolunteer(Volunteer model)
        {
            using (var cn3 = new SqlConnection(ConfigurationManager.ConnectionStrings["HopeTherapyIMS"].ConnectionString))

            {
                string sql = "SELECT (FirstName as FirstName AND LastName as LastName) FROM [dbo].[Volunteer] WHERE  ) ";
                try
                {
                    Utilities.Sql.ExecuteCommand(sql, model);
                }
                catch (SqlException ex)
                {
                    throw;
                }

            }
            return RedirectToAction("List", "Volunteer");

        }
        
    /*    public ActionResult Index(string searchString)
        {
            using (var cn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["HopeTherapyIMS"].ConnectionString))
                var volunteer = from m in [dbo].[Volunteer]
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                volunteer = volunteer.Where(s => s.Title.Contains(searchString));
            }

            return View(VolunteerSearch);
        }*/
        [HttpGet]
        public ActionResult List()
        {
            var Volunteers = Utilities.Sql.ExecuteQuery<Volunteer>("select FirstName as FirstName, LastName as LastName, Email as Email, HoursPerMonth as HoursPerMonth, VolunteerID as VolunteerID from dbo.Volunteer;");
            return View(Volunteers);

            
           
        }

    }
}
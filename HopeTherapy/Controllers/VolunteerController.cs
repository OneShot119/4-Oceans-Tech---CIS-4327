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

        private static readonly IEnumerable<SelectListItem> _VolunteerPositions = new List<SelectListItem>
        {
            new SelectListItem {Text="Lessons", Value="Lessons" },
            new SelectListItem { Text = "Horse Show", Value = "Horse Show" },
            new SelectListItem { Text = "Special Event", Value = "Special Event" },
            new SelectListItem {Text = "Fundraising", Value="Fundraising" },
            new SelectListItem { Text = "Facility Maintenance", Value = "Facility Maintenance" },
            new SelectListItem { Text = "Special Project", Value = "Special Project" },
            new SelectListItem { Text = "Computer Work", Value = "Computer Work" },
            new SelectListItem { Text = "Mailings", Value = "Mailings" }
        };
        // GET: Volunteer
        [HttpGet]
        public ActionResult Index()
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            var model = new Volunteer();
            model.VolunteerPositions = _VolunteerPositions;
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var Volunteers = Utilities.Sql.ExecuteQuerySingleResult<Volunteer>("select * from dbo.Volunteer WHERE Volunteer.VolunteerID = " + ID + ";");
                Volunteers.VolunteerPositions = _VolunteerPositions;
                return View(Volunteers);
            }
        }

        [HttpPost]
        public ActionResult EditVolunteer(Volunteer model)
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
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
        }

        [HttpPost]
        public ActionResult Index(Volunteer model)
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
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
                var Volunteer = new Volunteer();
                return RedirectToAction("Index", "Home");
            }
        }


        [HttpPost]
        public ActionResult SearchVolunteer(Volunteer model)
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                using (var cn3 = new SqlConnection(ConfigurationManager.ConnectionStrings["HopeTherapyIMS"].ConnectionString))

                {
                    string sql = "SELECT * FROM dbo.Volunteer";
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
        }

        /*    public ActionResult Index(string searchString)
            {
             if (!Request.IsAuthenticated)
             {
                 return RedirectToAction("Index", "Home");
             }
             else
             {
                using (var cn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["HopeTherapyIMS"].ConnectionString))
                    var volunteer = from m in [dbo].[Volunteer]
                             select m;

                if (!String.IsNullOrEmpty(searchString))
                {
                    volunteer = volunteer.Where(s => s.Title.Contains(searchString));
                }

                return View(VolunteerSearch);

             }
             }*/
        [HttpGet]
        public ActionResult List()
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var volunteers = Utilities.Sql.ExecuteQuery<Volunteer>("select FirstName as FirstName, LastName as LastName, Email as Email, HoursPerMonth as HoursPerMonth, VolunteerID as VolunteerID from dbo.Volunteer;");
                return View(volunteers);
            }
        }
        [HttpPost]
        public ActionResult List(string LastName)
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var Volunteers = Utilities.Sql.ExecuteQuery<Volunteer>("SELECT FirstName as FirstName, LastName as LastName, Email as Email, HoursPerMonth as HoursPerMonth, VolunteerID as VolunteerID from [dbo].[Volunteer] WHERE LastName LIKE '%" + LastName + "%';");
                return View(Volunteers);
            }
        }
    }
}
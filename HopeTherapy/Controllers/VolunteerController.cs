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

        private static readonly IEnumerable<SelectListItem> _VolunteerPositions = new SelectList(poslist());

        private static IEnumerable<string> poslist(){
            var Position = Utilities.Sql.ExecuteQuery<String>("select Positions from dbo.Position;");
            return Position;
        }
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
            model.StatesList = Utilities.states();
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
                IEnumerable<String> schedule = Utilities.Sql.ExecuteQuery<String>("select * from dbo.Days WHERE Days.Volunteer = " + ID + ";");
                Volunteers.VolunteerID = ID;
                Volunteers.dayList = schedule;
                Volunteers.setDays();
                Volunteers.VolunteerPositions = _VolunteerPositions;
                Volunteers.StatesList = Utilities.states();
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
                        "CellPhoneNumber=@CellPhoneNumber, HomePhoneNumber=@HomePhoneNumber, WorkPhoneNumber=@WorkPhoneNumber, Email=@Email, Birthday=@Birthday, Gender=@Gender, " +
                        "CompanyName=@CompanyName, Position=@Position, CompanyAddress=@CompanyAddress, DateOrientation=@DateOrientation, DateStarted=@DateStarted, HoursPerMonth=@HoursPerMonth," +
                        "VolunteerPosition=@VolunteerPosition, AreaOfInterest=@AreaOfInterest, Skills=@Skills, Donor=@Donor, Board=@Board, EmailList=@EmailList, MailList=@MailList " +
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
                
                int ID = model.VolunteerID;
                string sql3 = "DELETE FROM Days WHERE Volunteer = " + ID + ";";
                try
                {
                    Utilities.Sql.ExecuteCommand(sql3, model);
                }
                catch (SqlException ex)
                {
                    throw;
                }

                List<String> Schedule = model.Schedule();
                foreach (var Day in Schedule)
                {
                    string sql2 = "INSERT INTO [dbo].[Days] Values ('" + Day + "','" + ID + "');";
                    try
                    {
                        Utilities.Sql.ExecuteCommand(sql2, model);
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
                List<String> Schedule = model.Schedule();
                string sql = "INSERT INTO [dbo].[Volunteer] (FirstName, LastName, StreetAddress, City, States, ZipCode, County," +
                    "CellPhoneNumber, HomePhoneNumber, WorkPhoneNumber, Email, Birthday, Gender, CompanyName, Position, CompanyAddress," +
                    "DateOrientation, DateStarted, HoursPerMonth, VolunteerPosition, AreaOfInterest, Skills, Donor, Board, EmailList, MailList)" +
                    "VALUES(@FirstName, @LastName, @StreetAddress, @City, @States, @ZipCode, @County, @CellPhoneNumber, @HomePhoneNumber," +
                    "@WorkPhoneNumber, @Email, @Birthday, @Gender, @CompanyName, @Position, @CompanyAddress," +
                    "@DateOrientation, @DateStarted,  @HoursPerMonth, @VolunteerPosition, @AreaOfInterest, @Skills, @Donor, @Board, @EmailList, @MailList)";
                try
                {
                    Utilities.Sql.ExecuteCommand(sql, model);
                }
                catch (SqlException ex)
                {
                    throw;
                }
                string sql3 = "SELECT VolunteerID FROM Volunteer WHERE VolunteerID = (SELECT max(VolunteerID) FROM Volunteer)";
                int ID = Utilities.Sql.ExecuteQuerySingleResult<int>(sql3, model);
                foreach (var Day in Schedule)
                {
                    string sql2 = "INSERT INTO [dbo].[Days] Values ('" + Day + "','" + ID + "');";
                    try
                    {
                        Utilities.Sql.ExecuteCommand(sql2, model);
                    }
                    catch (SqlException ex)
                    {
                        throw;
                    }
                    
                }
            return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult List(String Search, String Type)
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                IEnumerable<Volunteer> Volunteers=null;
                if (Type=="LastName")
                {
                    Volunteers = Utilities.Sql.ExecuteQuery<Volunteer>("SELECT FirstName as FirstName, LastName as LastName, Email as Email, HoursPerMonth as HoursPerMonth, VolunteerID as VolunteerID from [dbo].[Volunteer] WHERE LastName LIKE '%" + Search + "%';");

                }
                else if (Type == "County")
                {
                    Volunteers = Utilities.Sql.ExecuteQuery<Volunteer>("SELECT FirstName as FirstName, LastName as LastName, Email as Email, HoursPerMonth as HoursPerMonth, VolunteerID as VolunteerID from [dbo].[Volunteer] WHERE County LIKE '%" + Search + "%';");

                }
                else if (Type == "*")
                {
                    Volunteers = Utilities.Sql.ExecuteQuery<Volunteer>("SELECT FirstName as FirstName, LastName as LastName, Email as Email, HoursPerMonth as HoursPerMonth, VolunteerID as VolunteerID from [dbo].[Volunteer] WHERE FirstName LIKE '%" + Search + "%' OR LastName LIKE '%" + Search + "%' OR Email LIKE '%" + Search + "%' OR StreetAddress LIKE '%" + Search + "%' OR City LIKE '%" + Search + "%' OR States LIKE '%" + Search + "%' OR ZipCode LIKE '%" + Search + "%' OR County LIKE '%" + Search + "%' OR CellPhoneNumber LIKE '%" + Search + "%' OR HomePhoneNumber LIKE '%" + Search + "%' OR WorkPhoneNumber LIKE '%" + Search + "%' OR Birthday LIKE '%" + Search + "%' OR Gender LIKE '%" + Search + "%' OR CompanyName LIKE '%" + Search + "%' OR Position LIKE '%" + Search + "%' OR CompanyAddress LIKE '%" + Search + "%' OR DateOrientation LIKE '%" + Search + "%' OR DateStarted LIKE '%" + Search + "%' OR HoursPerMonth LIKE '%" + Search + "%' OR AreaOfInterest LIKE '%" + Search + "%' OR Skills LIKE '%" + Search + "%';");
                }
                else if (Type == "Day")
                {
                    Volunteers = Utilities.Sql.ExecuteQuery<Volunteer>("SELECT FirstName as FirstName, LastName as LastName, Email as Email, HoursPerMonth as HoursPerMonth, VolunteerID as VolunteerID from [dbo].[Volunteer],[dbo].[Days] where Days.Volunteer = Volunteer.VolunteerID and Days.Day='" + Search + "';");
                    ViewBag.SearchDay = Search;
                }
                else
                {
                Volunteers = Utilities.Sql.ExecuteQuery<Volunteer>("select FirstName as FirstName, LastName as LastName, Email as Email, HoursPerMonth as HoursPerMonth, VolunteerID as VolunteerID from dbo.Volunteer;");
                }
                foreach(var Volunteer in Volunteers)
                {
                    IEnumerable<String> schedule = Utilities.Sql.ExecuteQuery<String>("select * from dbo.Days WHERE Days.Volunteer = " + Volunteer.VolunteerID + ";");
                    Volunteer.dayList = schedule;
                    Volunteer.setDays();
                }
                return View(Volunteers);
            }
        }

        [HttpPost]
        public ActionResult EmailList()
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                IEnumerable<Volunteer> Volunteers = null;
                Volunteers = Utilities.Sql.ExecuteQuery<Volunteer>("select VolunteerID as VolunteerID, FirstName as FirstName, LastName as LastName, Email as Email from dbo.Volunteer where EmailList = 'Y'");

                return View("Email", Volunteers);
            }
        }
        [HttpPost]
        public ActionResult MailList()
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                IEnumerable<Volunteer> Volunteers = null;
                Volunteers = Utilities.Sql.ExecuteQuery<Volunteer>("select VolunteerID as VolunteerID, FirstName as FirstName, LastName as LastName, StreetAddress as StreetAddress, CITY as City, STATES as States, ZIPCODE as ZipCode from dbo.Volunteer where MailList = 'Y'");
                return View("VMail", Volunteers);
            }
        }

        [HttpPost]
        public ActionResult ListByLastName(string LastName)
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("List",new {Search=LastName, Type="LastName" });
            }
        }
        [HttpPost]
        public ActionResult ListByCounty(string County)
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("List", new { Search = County, Type = "County" });
            }
        }
        public ActionResult ListByDay(string Day)
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (string.IsNullOrEmpty(Day))
            {
                return RedirectToAction("List", new { Search = "", Type = "" });
            }
            else
            {
                return RedirectToAction("List", new { Search = Day, Type = "Day" });
            }
        }
        public ActionResult ListByAll(string All)
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("List", new { Search = All, Type = "*" });
            }
        }
        public ActionResult Profile(int ID)
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var Volunteer = Utilities.Sql.ExecuteQuerySingleResult<Volunteer>("select * from dbo.Volunteer WHERE Volunteer.VolunteerID = " + ID + ";");
                IEnumerable<String> schedule = Utilities.Sql.ExecuteQuery<String>("select * from dbo.Days WHERE Days.Volunteer = " + ID + ";");
                Volunteer.dayList = schedule;
                Volunteer.setDays();
                return View(Volunteer);
            }
        }
        public ActionResult Delete(int id)
        {
            String sql = "Delete from dbo.Days where Volunteer =" + id;
            Utilities.Sql.ExecuteCommand(sql);

            sql = "Delete from dbo.Volunteer where volunteerId =" + id;
            Utilities.Sql.ExecuteCommand(sql);
            return RedirectToAction("List", "Volunteer");
        }


    }
}

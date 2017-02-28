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
        private static readonly IEnumerable<SelectListItem> _StatesList = new List<SelectListItem>
        {
            new SelectListItem {Text="", Value=""},
            new SelectListItem {Text="Alabama", Value="Alabama"},
            new SelectListItem {Text="Alaska", Value="Alaska"},
            new SelectListItem {Text="Arizona", Value="Arizona"},
            new SelectListItem {Text="Arkansas", Value="Arkansas"},
            new SelectListItem {Text="California", Value="California"},
            new SelectListItem {Text="Colorado", Value="Colorado"},
            new SelectListItem {Text="Connecticut", Value="Connecticut"},
            new SelectListItem {Text="Delaware", Value="Delaware"},
            new SelectListItem {Text="District Of Columbia", Value="District Of Columbia"},
            new SelectListItem {Text="Florida", Value="Florida"},
            new SelectListItem {Text="Georgia", Value="Georgia"},
            new SelectListItem {Text="Hawaii", Value="Hawaii"},
            new SelectListItem {Text="Idaho", Value="Idaho"},
            new SelectListItem {Text="Illinois", Value="Illinois"},
            new SelectListItem {Text="Indiana", Value="Indiana"},
            new SelectListItem {Text="Iowa", Value="Iowa"},
            new SelectListItem {Text="Kansas", Value="Kansas"},
            new SelectListItem {Text="Kentucky", Value="Kentucky"},
            new SelectListItem {Text="Louisiana", Value="Louisiana"},
            new SelectListItem {Text="Maine", Value="Maine"},
            new SelectListItem {Text="Maryland", Value="Maryland"},
            new SelectListItem {Text="Massachusetts", Value="Massachusetts"},
            new SelectListItem {Text="Michigan", Value="Michigan"},
            new SelectListItem {Text="Minnesota", Value="Minnesota"},
            new SelectListItem {Text="Mississippi", Value="Mississippi"},
            new SelectListItem {Text="Missouri", Value="Missouri"},
            new SelectListItem {Text="Montana", Value="Montana"},
            new SelectListItem {Text="Nebraska", Value="Nebraska"},
            new SelectListItem {Text="Nevada", Value="Nevada"},
            new SelectListItem {Text="New Hampshire", Value="New Hampshire"},
            new SelectListItem {Text="New Jersey", Value="New Jersey"},
            new SelectListItem {Text="New Mexico", Value="New Mexico"},
            new SelectListItem {Text="New York", Value="New York"},
            new SelectListItem {Text="North Carolina", Value="North Carolina"},
            new SelectListItem {Text="North Dakota", Value="North Dakota"},
            new SelectListItem {Text="Ohio", Value="Ohio"},
            new SelectListItem {Text="Oklahoma", Value="Oklahoma"},
            new SelectListItem {Text="Oregon", Value="Oregon"},
            new SelectListItem {Text="Pennsylvania", Value="Pennsylvania"},
            new SelectListItem {Text="Rhode Island", Value="Rhode Island"},
            new SelectListItem {Text="South Carolina", Value="South Carolina"},
            new SelectListItem {Text="South Dakota", Value="South Dakota"},
            new SelectListItem {Text="Tennessee", Value="Tennessee"},
            new SelectListItem {Text="Texas", Value="Texas"},
            new SelectListItem {Text="Utah", Value="Utah"},
            new SelectListItem {Text="Vermont", Value="Vermont"},
            new SelectListItem {Text="Virginia", Value="Virginia"},
            new SelectListItem {Text="West Virginia", Value="West Virginia"},
            new SelectListItem {Text="Wisconsin", Value="Wisconsin"},
            new SelectListItem {Text="Wyoming", Value="Wyoming"}
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
            model.StatesList = _StatesList;
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
                else
                {
                Volunteers = Utilities.Sql.ExecuteQuery<Volunteer>("select FirstName as FirstName, LastName as LastName, Email as Email, HoursPerMonth as HoursPerMonth, VolunteerID as VolunteerID from dbo.Volunteer;");
                }
                return View(Volunteers);
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
    }
}
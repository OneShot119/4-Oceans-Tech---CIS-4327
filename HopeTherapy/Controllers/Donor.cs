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
    public class DonorController : Controller
    {
        // GET: Register
        [HttpGet]
        public ActionResult Index()
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
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
                var Donor = Utilities.Sql.ExecuteQuerySingleResult<Donor>("select D_CODE as DonorID, D_Fname as FirstName, D_Lname as LastName, D_address as StreetAddress, D_CITY as City, D_STATE as State, D_ZIP as ZipCode, D_County as County, D_BIRTHDAY as Birthday, D_GENDER as Gender, D_CELL_PHONE as CellPhoneNumber, D_HOME_PHONE as HomePhoneNumber, D_WORK_PHONE as WorkPhoneNumber, D_EMAIL as EmailAddress, D_CO_NAME as CompanyName, D_POSITION as Position, D_CO_ADDRESS as CompanyAddress, D_CO_STATE as CompanyState, D_CO_CITY as CompanyCity, D_CO_ZIP as CompanyZip, DONATION_DATE as DonationDate, DONATION_CURRENCY as CurrencyDonation, DONATION_ITEM as ItemDonation, DONATION_SERVICE as ServiceDonation from dbo.DONOR Where D_CODE = " + ID + ";");
                return View(Donor);
            }
        }

        [HttpPost]
        public ActionResult EditDonor(Donor model)
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                using (var cn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["HopeTherapyIMS"].ConnectionString))

                {
                    string sql = "UPDATE [dbo].[DONOR] SET D_Fname = @FirstName, D_Lname = @LastName, " +
                        "D_address = @StreetAddress, D_CITY = @City, D_STATE = @State, D_ZIP = @ZipCode, D_County = @County, D_BIRTHDAY = @Birthday, " +
                        "D_GENDER = @Gender, D_CELL_PHONE = @CellPhoneNumber, D_HOME_PHONE = @HomePhoneNumber, D_WORK_PHONE = @WorkPhoneNumber, " +
                        "D_EMAIL = @EmailAddress, D_CO_NAME = @CompanyName, D_POSITION = @Position, D_CO_ADDRESS = @CompanyAddress, " +
                        "D_CO_STATE = @CompanyState, D_CO_CITY = @CompanyCity, D_CO_ZIP = @CompanyZip, DONATION_DATE = @DonationDate, " +
                        "DONATION_CURRENCY = @CurrencyDonation, DONATION_ITEM = @ItemDonation, DONATION_SERVICE = @ServiceDonation " +
                        "WHERE D_CODE = @DonorID;";
                    try
                    {
                        Utilities.Sql.ExecuteCommand(sql, model);
                    }
                    catch (SqlException ex)
                    {
                        throw;
                    }

                }

                return RedirectToAction("List", "Donor");
            }
        }
        [HttpPost]

        public ActionResult Index(Donor model)
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                using (var cn3 = new SqlConnection(ConfigurationManager.ConnectionStrings["HopeTherapyIMS"].ConnectionString))
                {
                    string sql = "INSERT INTO [dbo].[DONOR] (D_FNAME, D_LNAME, D_ADDRESS, D_CITY, D_STATE, D_ZIP, D_COUNTY, D_BIRTHDAY, D_GENDER, D_CELL_PHONE, " +
                    "D_HOME_PHONE, D_WORK_PHONE, D_EMAIL, D_CO_NAME, D_POSITION, D_CO_ADDRESS, D_CO_CITY, D_CO_STATE, D_CO_ZIP, " +
                    "DONATION_DATE, DONATION_CURRENCY, DONATION_ITEM, DONATION_SERVICE )" +
                    "VALUES(@FirstName, @LastName, @StreetAddress, @City, @State, @ZipCode, @County, @Birthday, @Gender, " +
                    "@CellPhoneNumber, @HomePhoneNumber, @WorkPhoneNumber, @EmailAddress, @CompanyName, @Position, @CompanyAddress, @CompanyCity, @CompanyState, " +
                    "@CompanyZip, @DonationDate, @CurrencyDonation, @ItemDonation, @ServiceDonation)";

                    try
                    {
                        Utilities.Sql.ExecuteCommand(sql, model);
                    }
                    catch (SqlException ex)
                    {

                        throw;
                    }

                }
                var Donor = new Donor();

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
                IEnumerable<Donor> Donors = null;
                if (Type == "LastName")
                {
                    Donors = Utilities.Sql.ExecuteQuery<Donor>("select D_CODE as DonorID, D_Fname as FirstName, D_Lname as LastName, D_EMAIL as EmailAddress, DONATION_DATE as DonationDate, DONATION_CURRENCY as CurrencyDonation, DONATION_ITEM as ItemDonation, DONATION_SERVICE as ServiceDonation from dbo.DONOR WHERE D_LName LIKE '%" + Search + "%';");

                }
                else if (Type == "County")
                {
                    Donors = Utilities.Sql.ExecuteQuery<Donor>("select D_CODE as DonorID, D_Fname as FirstName, D_Lname as LastName, D_EMAIL as EmailAddress, DONATION_DATE as DonationDate, DONATION_CURRENCY as CurrencyDonation, DONATION_ITEM as ItemDonation, DONATION_SERVICE as ServiceDonation from dbo.DONOR WHERE D_COUNTY LIKE '%" + Search + "%';");

                }
                else
                {
                    Donors = Utilities.Sql.ExecuteQuery<Donor>("select D_CODE as DonorID, D_Fname as FirstName, D_Lname as LastName, D_EMAIL as EmailAddress, DONATION_DATE as DonationDate, DONATION_CURRENCY as CurrencyDonation, DONATION_ITEM as ItemDonation, DONATION_SERVICE as ServiceDonation from dbo.DONOR;");
                }
                return View(Donors);
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
                return RedirectToAction("List", new { Search = LastName, Type = "LastName" });
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



    
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
            return View();
        }

        [HttpPost]

        public ActionResult Index(Donor model)
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
        [HttpGet]
        public ActionResult List()
        {
            var emails = Utilities.Sql.ExecuteQuery<Donor>("select D_Fname as FirstName, D_Lname as LastName, D_EMAIL as EmailAddress, DONATION_DATE as DonationDate, DONATION_CURRENCY as CurrencyDonation, DONATION_ITEM as ItemDonation, DONATION_SERVICE as ServiceDonation from dbo.DONOR;");
            return View(emails);

        }
    }
}


    
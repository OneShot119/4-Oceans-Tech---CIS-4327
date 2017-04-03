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
    public class DonorController : Controller
    {

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


        // GET: Register
           [HttpGet]
        public ActionResult Index()
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            var model = new Donor();
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
                else if (Type == "*")
                {
                    Donors = Utilities.Sql.ExecuteQuery<Donor>("select D_CODE as DonorID, D_Fname as FirstName, D_Lname as LastName, D_EMAIL as EmailAddress, DONATION_DATE as DonationDate, DONATION_CURRENCY as CurrencyDonation, DONATION_ITEM as ItemDonation, DONATION_SERVICE as ServiceDonation from dbo.DONOR WHERE D_FNAME LIKE '%" + Search + "%' OR D_lname LIKE '%" + Search + "%' OR d_address LIKE '%" + Search + "%' OR d_city LIKE '%" + Search + "%' OR d_state LIKE '%" + Search + "%' OR d_zip LIKE '%" + Search + "%' OR d_county LIKE '%" + Search + "%' OR d_birthday LIKE '%" + Search + "%' OR d_gender LIKE '%" + Search + "%' OR d_cell_phone LIKE '%" + Search + "%' OR d_home_phone LIKE '%" + Search + "%' OR d_work_phone LIKE '%" + Search + "%' OR d_email LIKE '%" + Search + "%' OR d_co_name LIKE '%" + Search + "%' OR d_position LIKE '%" + Search + "%' OR d_co_address LIKE '%" + Search + "%' OR d_co_city LIKE '%" + Search + "%' OR d_co_state LIKE '%" + Search + "%' OR d_co_zip LIKE '%" + Search + "%' OR donation_date LIKE '%" + Search + "%' OR donation_currency LIKE '%" + Search + "%' OR donation_item LIKE '%" + Search + "%' OR donation_service LIKE '%" + Search + "%';");


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
        [HttpPost]
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
                var Donor = Utilities.Sql.ExecuteQuerySingleResult<Donor>("select D_CODE as DonorID, D_Fname as FirstName, D_Lname as LastName, D_address as StreetAddress, D_CITY as City, D_STATE as State, D_ZIP as ZipCode, D_County as County, D_BIRTHDAY as Birthday, D_GENDER as Gender, D_CELL_PHONE as CellPhoneNumber, D_HOME_PHONE as HomePhoneNumber, D_WORK_PHONE as WorkPhoneNumber, D_EMAIL as EmailAddress, D_CO_NAME as CompanyName, D_POSITION as Position, D_CO_ADDRESS as CompanyAddress, D_CO_STATE as CompanyState, D_CO_CITY as CompanyCity, D_CO_ZIP as CompanyZip, DONATION_DATE as DonationDate, DONATION_CURRENCY as CurrencyDonation, DONATION_ITEM as ItemDonation, DONATION_SERVICE as ServiceDonation from dbo.DONOR Where D_CODE = " + ID + ";");
                return View(Donor);
            }
        }
        public ActionResult Delete(int id)
        {
            String sql = "Delete from dbo.DONOR where D_CODE =" + id;
            Utilities.Sql.ExecuteCommand(sql);
            return RedirectToAction("List", "Donor");
        }
    }
}



    
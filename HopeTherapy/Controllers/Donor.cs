using HopeTherapy.DataAccess;
using HopeTherapy.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Web.Security;

namespace HopeTherapy.Controllers
{
    public class DonorController : Controller
    {



        // GET: Register
        [HttpGet]
        public ActionResult NewDonor()
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            var model = new Donor();
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
                var Donor = Utilities.Sql.ExecuteQuerySingleResult<Donor>("select D_CODE as DonorID, D_Fname as FirstName, D_Lname as LastName, D_address as StreetAddress, D_CITY as City, D_STATE as State, D_ZIP as ZipCode, D_County as County, D_CELL_PHONE as CellPhoneNumber, D_HOME_PHONE as HomePhoneNumber, D_WORK_PHONE as WorkPhoneNumber, D_EMAIL as EmailAddress, D_MailList as MailList, D_EmailList as EmailList, D_CO_NAME as CompanyName, D_POSITION as Position, D_CO_ADDRESS as CompanyAddress, D_CO_STATE as CompanyState, D_CO_CITY as CompanyCity, D_CO_ZIP as CompanyZip, notes as Notes from dbo.DONOR Where D_CODE = " + ID + ";");
                Donor.StatesList = Utilities.states(); 
                IEnumerable<Donation> CDonations = null;
                IEnumerable<Donation> Donations = null;
                CDonations = Utilities.Sql.ExecuteQuery<Donation>("SELECT D_FNAME as donorFName, D_LNAME as donorLName, CurrencyDonation.dod as date, amount as donationAmount, D_CODE as donorID from [dbo].[donor],[dbo].[CurrencyDonation] where CurrencyDonation.donorID = Donor.D_CODE and Donor.D_CODE=" + ID + ";");
                Donations = Utilities.Sql.ExecuteQuery<Donation>("SELECT D_FNAME as donorFName, D_LNAME as donorLName, ItemDonation.dod as date, Donation as donationItem, D_CODE as donorID from [dbo].[donor],[dbo].[ItemDonation] where ItemDonation.donorID = Donor.D_CODE and Donor.D_CODE=" + ID + "; ");
                foreach (var CDonation in CDonations)
                {
                    Donor.CurrencyDonation += CDonation.donationAmount;
                }
                foreach (var Donation in Donations)
                {
                    Donor.ServiceDonation += (Donation.donationItem + System.Environment.NewLine);
                }
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
                        "D_address = @StreetAddress, D_CITY = @City, D_STATE = @State, D_ZIP = @ZipCode, D_County = @County, " +
                        "D_CELL_PHONE = @CellPhoneNumber, D_HOME_PHONE = @HomePhoneNumber, D_WORK_PHONE = @WorkPhoneNumber, " +
                        "D_EMAIL = @EmailAddress, D_MailList = @MailList, D_EmailList = @EmailList, D_CO_NAME = @CompanyName, D_POSITION = @Position, D_CO_ADDRESS = @CompanyAddress, " +
                        "D_CO_STATE = @CompanyState, D_CO_CITY = @CompanyCity, D_CO_ZIP = @CompanyZip, notes = @Notes " +
                        "WHERE D_CODE = @DonorID;";
                    if (model.NewDonation != 0)
                    {
                    try
                    {
                        {
                            String CSQL = "insert into CurrencyDonation values(" + model.NewDonation + ", '" + model.DonationDate + "', " + model.DonorID + ");";
                            Utilities.Sql.ExecuteCommand(CSQL, model);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    }


                    IEnumerable<String> OldDonations = Utilities.Sql.ExecuteQuery<String>("SELECT donation from [dbo].[ItemDonation] where donorid=" + model.DonorID + "; ");
                    List<String> newDonations = new List<string>();
                    try
                    {
                        using (StringReader reader = new StringReader(model.ServiceDonation))
                        {
                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                if (String.IsNullOrWhiteSpace(line) == false && OldDonations.Contains<String>(line) == false)
                                {
                                    newDonations.Add(line);
                                    String SSQL = "insert into ItemDonation (donation,dod,donorid) values('" + line + "', '" + model.DonationDate + "', " + model.DonorID + ");";
                                    Utilities.Sql.ExecuteCommand(SSQL, model);
                                }

                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }


                    try
                    {
                        Utilities.Sql.ExecuteCommand(sql, model);
                    }
                    catch (SqlException ex)
                    {
                        throw;
                    }
                    DateTime mRD = Utilities.Sql.ExecuteQuerySingleResult<DateTime>("SELECT D_MOST_RECENT from [dbo].[DONOR] where d_CODE=" + model.DonorID + "; ");
                    if ((model.NewDonation!=0 || newDonations.Any<String>()) && mRD < model.DonationDate)
                    {
                        String DateSQL = "update donor set d_most_recent = '"+model.DonationDate+"' where d_code = "+ model.DonorID+"; ";
                        Utilities.Sql.ExecuteCommand(DateSQL, model);
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
                string sql = "INSERT INTO [dbo].[DONOR] (D_FNAME, D_LNAME, D_ADDRESS, D_CITY, D_STATE, D_ZIP, D_COUNTY, D_CELL_PHONE, " +
                "D_HOME_PHONE, D_WORK_PHONE, D_EMAIL, D_MailList, D_EmailList, D_CO_NAME, D_POSITION, D_CO_ADDRESS, D_CO_CITY, D_CO_STATE, D_CO_ZIP, d_most_recent, notes)" +
                "VALUES(@FirstName, @LastName, @StreetAddress, @City, @State, @ZipCode, @County, " +
                "@CellPhoneNumber, @HomePhoneNumber, @WorkPhoneNumber, @EmailAddress, @MailList, @EmailList, @CompanyName, @Position, @CompanyAddress, @CompanyCity, @CompanyState, " +
                "@CompanyZip, @DonationDate, @notes)";

                try
                {
                    Utilities.Sql.ExecuteCommand(sql, model);
                }
                catch (SqlException ex)
                {

                    throw;
                }

                String donorIdSql = "SELECT D_CODE FROM DONOR WHERE D_CODE = (SELECT max(D_CODE) FROM DONOR)";
                string donorID = Utilities.Sql.ExecuteQuerySingleResult<String>(donorIdSql);
                String CSQL = "insert into CurrencyDonation values(" + model.CurrencyDonation + ", '" + model.DonationDate + "', " + donorID + ");";
                Utilities.Sql.ExecuteCommand(CSQL, model);
                try
                {
                    using (StringReader reader = new StringReader(model.ItemDonation))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            String ISQL = "insert into ItemDonation (donation,dod,donorid) values ('" + line + "', '" + model.DonationDate + "', " + donorID + ");";
                            Utilities.Sql.ExecuteCommand(ISQL, model);
                        }
                    }
                }
                catch (Exception ex)
                {
                    
                }

                try
                {
                    using (StringReader reader = new StringReader(model.ServiceDonation))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            String SSQL = "insert into ItemDonation (donation,dod,donorid) values('" + line + "', '" + model.DonationDate + "', " + donorID + ");";
                            Utilities.Sql.ExecuteCommand(SSQL, model);
                        }
                    }
                }

                catch (Exception ex)
                {
                    
                }



                return RedirectToAction("Index", "Home");
            }
        }
        [HttpGet]
        public ActionResult List(String Search, String Type, int? page)
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
                    Donors = Utilities.Sql.ExecuteQuery<Donor>("select D_CODE as DonorID, D_Fname as FirstName, D_Lname as LastName, D_EMAIL as EmailAddress, d_most_recent as DonationDate, DONATION_CURRENCY as CurrencyDonation, DONATION_ITEM as ItemDonation, DONATION_SERVICE as ServiceDonation from dbo.DONOR WHERE D_LName LIKE '%" + Search + "%';");
                    ViewBag.SearchType = Type;
                    ViewBag.SearchString = Search;
                }
                else if (Type == "County")
                {
                    Donors = Utilities.Sql.ExecuteQuery<Donor>("select D_CODE as DonorID, D_Fname as FirstName, D_Lname as LastName, D_EMAIL as EmailAddress, d_most_recent as DonationDate, DONATION_CURRENCY as CurrencyDonation, DONATION_ITEM as ItemDonation, DONATION_SERVICE as ServiceDonation from dbo.DONOR WHERE D_COUNTY LIKE '%" + Search + "%';");
                    ViewBag.SearchType = Type;
                    ViewBag.SearchString = Search;
                }
                else if (Type == "*")
                {
                    Donors = Utilities.Sql.ExecuteQuery<Donor>("select D_CODE as DonorID, D_Fname as FirstName, D_Lname as LastName, D_EMAIL as EmailAddress, d_most_recent as DonationDate, DONATION_CURRENCY as CurrencyDonation, DONATION_ITEM as ItemDonation, DONATION_SERVICE as ServiceDonation from dbo.DONOR WHERE D_FNAME LIKE '%" + Search + "%' OR D_lname LIKE '%" + Search + "%' OR d_address LIKE '%" + Search + "%' OR d_city LIKE '%" + Search + "%' OR d_state LIKE '%" + Search + "%' OR d_zip LIKE '%" + Search + "%' OR d_county LIKE '%" + Search + "%' OR d_cell_phone LIKE '%" + Search + "%' OR d_home_phone LIKE '%" + Search + "%' OR d_work_phone LIKE '%" + Search + "%' OR d_email LIKE '%" + Search + "%' OR d_co_name LIKE '%" + Search + "%' OR d_position LIKE '%" + Search + "%' OR d_co_address LIKE '%" + Search + "%' OR d_co_city LIKE '%" + Search + "%' OR d_co_state LIKE '%" + Search + "%' OR d_co_zip LIKE '%" + Search + "%' OR d_most_recent LIKE '%" + Search + "%' OR donation_currency LIKE '%" + Search + "%' OR donation_item LIKE '%" + Search + "%' OR donation_service LIKE '%" + Search + "%';");
                    ViewBag.SearchType = Type;
                    ViewBag.SearchString = Search;
                }
                else
                {
                    Donors = Utilities.Sql.ExecuteQuery<Donor>("select D_CODE as DonorID, D_Fname as FirstName, D_Lname as LastName, D_EMAIL as EmailAddress, d_most_recent as DonationDate, DONATION_CURRENCY as CurrencyDonation, DONATION_ITEM as ItemDonation, DONATION_SERVICE as ServiceDonation from dbo.DONOR;");
                }
                int pageSize = 7;
                int pageNumber = (page ?? 1);
                return View(Donors.ToPagedList(pageNumber, pageSize));
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
                IEnumerable<Donor> Donors = null;
                Donors = Utilities.Sql.ExecuteQuery<Donor>("select D_CODE as DonorID, D_Fname as FirstName, D_Lname as LastName, D_address as StreetAddress, D_CITY as City, D_STATE as State, D_ZIP as ZipCode from dbo.DONOR where D_MailList = 'Y'");
                return View("DMail", Donors);
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
                IEnumerable<Donor> Donors = null;
                Donors = Utilities.Sql.ExecuteQuery<Donor>("select D_CODE as DonorID, D_Fname as FirstName, D_Lname as LastName, D_EMAIL as EmailAddress from dbo.DONOR where D_EmailList = 'Y'");
                List<Donor> Dlist = Donors.ToList<Donor>();
                return View("DEmail", Dlist);
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
                var Donor = Utilities.Sql.ExecuteQuerySingleResult<Donor>("select D_CODE as DonorID, D_Fname as FirstName, D_Lname as LastName, D_address as StreetAddress, D_CITY as City, D_STATE as State, D_ZIP as ZipCode, D_County as County, D_CELL_PHONE as CellPhoneNumber, D_HOME_PHONE as HomePhoneNumber, D_WORK_PHONE as WorkPhoneNumber, D_EMAIL as EmailAddress, D_MailList as MailList, D_EmailList as EmailList, D_CO_NAME as CompanyName, D_POSITION as Position, D_CO_ADDRESS as CompanyAddress, D_CO_STATE as CompanyState, D_CO_CITY as CompanyCity, D_CO_ZIP as CompanyZip, D_most_recent as DonationDate, notes as Notes from dbo.DONOR Where D_CODE = " + ID + ";");
                IEnumerable<Donation> CDonations = null;
                IEnumerable<Donation> Donations = null;
                CDonations = Utilities.Sql.ExecuteQuery<Donation>("SELECT D_FNAME as donorFName, D_LNAME as donorLName, CurrencyDonation.dod as date, amount as donationAmount, D_CODE as donorID from [dbo].[donor],[dbo].[CurrencyDonation] where CurrencyDonation.donorID = Donor.D_CODE and Donor.D_CODE="+ID+";");
                Donations = Utilities.Sql.ExecuteQuery<Donation>("SELECT D_FNAME as donorFName, D_LNAME as donorLName, ItemDonation.dod as date, Donation as donationItem, D_CODE as donorID from [dbo].[donor],[dbo].[ItemDonation] where ItemDonation.donorID = Donor.D_CODE and Donor.D_CODE=" + ID +"; ");
                foreach(var CDonation in CDonations)
                {
                    Donor.CurrencyDonation += CDonation.donationAmount;
                }
                foreach(var Donation in Donations)
                {
                    Donor.ServiceDonation += (Donation.donationItem +" - "+ Donation.date.Month +"/"+ Donation.date.Day + "/" + Donation.date.Year+ System.Environment.NewLine);
                }
                return View(Donor);
            }
        }
        public ActionResult Delete(int id)
        {
            string sql = "delete from dbo.CurrencyDonation where donorid =" + id;
            Utilities.Sql.ExecuteCommand(sql);
            sql = "delete from dbo.ItemDonation where donorid =" + id;
            Utilities.Sql.ExecuteCommand(sql);

            sql = "Delete from dbo.DONOR where D_CODE =" + id;
            Utilities.Sql.ExecuteCommand(sql);
            return RedirectToAction("List", "Donor");
        }
        public ActionResult Donations()
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(findDonations());
            }

        }
        public IEnumerable<Donation> findDonations()
        {

            IEnumerable<Donation> CDonations = null;
            IEnumerable<Donation> Donations = null;
            CDonations = Utilities.Sql.ExecuteQuery<Donation>("SELECT D_FNAME as donorFName, D_LNAME as donorLName, CurrencyDonation.dod as date, amount as donationAmount, D_CODE as donorID from [dbo].[donor],[dbo].[CurrencyDonation] where CurrencyDonation.donorID = Donor.D_CODE;");
            Donations = Utilities.Sql.ExecuteQuery<Donation>("SELECT D_FNAME as donorFName, D_LNAME as donorLName, ItemDonation.dod as date, Donation as donationItem, D_CODE as donorID from [dbo].[donor],[dbo].[ItemDonation] where ItemDonation.donorID = Donor.D_CODE;");
            var TDonations = CDonations.Concat(Donations);
            return TDonations;
        }
        public IEnumerable<Donation> findDonations(DateTime first, DateTime second)
        {
            IEnumerable<Donation> CDonations = null;
            IEnumerable<Donation> Donations = null;
            CDonations = Utilities.Sql.ExecuteQuery<Donation>("SELECT D_FNAME as donorFName, D_LNAME as donorLName, CurrencyDonation.dod as date, amount as donationAmount, D_CODE as donorID from [dbo].[donor],[dbo].[CurrencyDonation] where CurrencyDonation.donorID = Donor.D_CODE and dod between '"+first+"' and '"+second+"';");
            Donations = Utilities.Sql.ExecuteQuery<Donation>("SELECT D_FNAME as donorFName, D_LNAME as donorLName, ItemDonation.dod as date, Donation as donationItem, D_CODE as donorID from [dbo].[donor],[dbo].[ItemDonation] where ItemDonation.donorID = Donor.D_CODE and dod between '" + first + "' and '" + second + "';");
            var TDonations = CDonations.Concat(Donations);
            return TDonations;
        }
        [HttpPost]
        public ActionResult SearchDate(DateTime first, DateTime second)
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var search = new DonationSeach();
                search.first = first;
                search.second = second;
                search.values = true;
                return View("Donations", findDonations(first, second));
            }
        }
        public IEnumerable<Donation> donationsBefore(DateTime date){
            IEnumerable<Donation> CDonations = null;
            IEnumerable<Donation> Donations = null;
            CDonations = Utilities.Sql.ExecuteQuery<Donation>("SELECT D_FNAME as donorFName, D_LNAME as donorLName, CurrencyDonation.dod as date, amount as donationAmount, D_CODE as donorID from [dbo].[donor],[dbo].[CurrencyDonation] where CurrencyDonation.donorID = Donor.D_CODE and dod < '" + date + "';");
            Donations = Utilities.Sql.ExecuteQuery<Donation>("SELECT D_FNAME as donorFName, D_LNAME as donorLName, ItemDonation.dod as date, Donation as donationItem, D_CODE as donorID from [dbo].[donor],[dbo].[ItemDonation] where ItemDonation.donorID = Donor.D_CODE and dod < '" + date + "';");
            var TDonations = CDonations.Concat(Donations);
            return TDonations;
        }
        public IEnumerable<Donation> donationsAfter(DateTime date)
        {
            IEnumerable<Donation> CDonations = null;
            IEnumerable<Donation> Donations = null;
            CDonations = Utilities.Sql.ExecuteQuery<Donation>("SELECT D_FNAME as donorFName, D_LNAME as donorLName, CurrencyDonation.dod as date, amount as donationAmount, D_CODE as donorID from [dbo].[donor],[dbo].[CurrencyDonation] where CurrencyDonation.donorID = Donor.D_CODE and dod > '" + date + "';");
            Donations = Utilities.Sql.ExecuteQuery<Donation>("SELECT D_FNAME as donorFName, D_LNAME as donorLName, ItemDonation.dod as date, Donation as donationItem, D_CODE as donorID from [dbo].[donor],[dbo].[ItemDonation] where ItemDonation.donorID = Donor.D_CODE and dod > '" + date + "';");
            var TDonations = CDonations.Concat(Donations);
            return TDonations;
        }
        public ActionResult listDonationsBefore(DateTime date)
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Donations", donationsBefore(date));
            }

        }
        public ActionResult listDonationsAfter(DateTime date)
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Donations", donationsAfter(date));
            }

        }
    }
}




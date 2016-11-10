using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HopeTherapy.Models;
using System.Web.Mvc;
using System.Configuration;
using System.Data.SqlClient;
using HopeTherapy;
using System.Reflection;

namespace HopeTherapy.Controllers
{
 
    public class DonorShow : Controller { }
    /*
        // GET: Donor
        [HttpGet]
        public ActionResult Index(Donor model)
        {
        var regCode = ConfigurationManager.AppSettings["RegCode"];
        using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["HopeTherapyIMS"].ConnectionString))
        {
        public string sql = "SELECT * FROM DONORS WHERE D_CODE=@code";
        try
                {
                    Utilities.Sql.ExecuteCommand(sql, model);
                }
        catch (SqlException ex)
        {
                if(ex.Number == 2627) // 2627 = unique constraint violation.
                {
                    ModelState.AddModelError("Username", "Username already taken.");
                    return View(model);
                }
                throw;
        }
        return View();
        }
        }
        
    [HttpPost]
    public ActionResult Index(DonorShow model) { }
        using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["HopeTherapyIMS"].ConnectionString))
            private string sql = "UPDATE DONOR SET (D_FNAME=@fName, D_LNAME=@lName, D_ADDRESS=@address, D_CITY=@city, D_STATE=@state, D_ZIP=@zip, D_COUNTY=@county, D_BIRTHDAY=@birthday, D_GENDER=@gender, D_CELL_PHONE=@cellPhone, D_HOME_PHONE=@homePhone, D_WORK_PHONE=@workPhone, D_EMAIL=@email, D_CO_NAME=@coName, D_POSITION=@position, D_CO_ADDRESS=@CoAddress, D_CO_CITY=@coCity, D_CO_STATE=@coState, D_CO_ZIP=@coZip, DONATION_CURRENCY=@donationCurrency, DONATION_ITEM=@donationItem, DONATION_SERVICE=@donationService) WHERE (D_CODE = $code)";
            try
                {
                    Utilities.Sql.ExecuteCommand(sql, Module);
                }
                catch (SqlException ex)
                {
                    throw;
                }
                DataAccess.SqlDataAccess.ExecuteCommand(sql);            
                return View(model);
        */
}
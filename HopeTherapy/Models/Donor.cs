using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HopeTherapy.Models
{
    public class Donor
    {
        private DateTime _date = DateTime.Now;


        public int DonorID { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Street Address")]
        public string StreetAddress { get; set; }

        [DisplayName("City Name")]
        public string City { get; set; }

        [DisplayName("State")]
        public string State { get; set; }
        public IEnumerable<SelectListItem> StatesList { get; set; }

        [DisplayName("Zip Code (5 digit)")]
        // [RegularExpression("^[0 - 9]{5}(-[0-9]{4})?$", ErrorMessage = "5 characters required")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "County is required")]
        [DisplayName("County")]
        public string County { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [DisplayName("Gender")]
        public string Gender { get; set; }

        [DisplayName("Cell Phone")]
        public string CellPhoneNumber { get; set; }

        [DisplayName("Home Phone")]
        public string HomePhoneNumber { get; set; }

        [DisplayName("Business Phone")]
        public string WorkPhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        //[Required(ErrorMessage = "Email is required")]
        [DisplayName("Email")]
        public string EmailAddress { get; set; }

        public string CompanyName { get; set; }

        public string Position { get; set; }

        public string CompanyAddress { get; set; }

        public string CompanyCity { get; set; }

        [DisplayName("Company State")]
        public string CompanyState { get; set; }

        public string CompanyZip { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Donation Date is required")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Donation Date ")]
        public DateTime DonationDate
        {
            get { return _date; }
            set { _date = value; }
        }

        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        //[DisplayName("Donation Currency")]
        public Double CurrencyDonation { get; set; }

        public string ItemDonation { get; set; }

        public string ServiceDonation { get; set; }

        [Required(ErrorMessage = "Email List is required")]
        [DisplayName("Email List? ")]
        public string EmailList { get; set; }

        [Required(ErrorMessage = "Mail List is required")]
        [DisplayName("Mail List? ")]
        public string MailList { get; set; }

        public string emailChain()
        {
            return (this.EmailAddress + ";");
        }
    }

}

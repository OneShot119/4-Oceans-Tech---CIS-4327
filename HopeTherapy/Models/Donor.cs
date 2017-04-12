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

        public int DonorID { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [DisplayName("First Name - Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [DisplayName("Last Name - Required")]
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

        [DisplayName("County - Required")]
        public string County { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Donation Date is required")]
        [DisplayName("Date of Birth *")]
        public string Birthday { get; set; }

        [Required(ErrorMessage = "Gender *")]
        [DisplayName("Gender - Required")]
        public string Gender { get; set; }

        [DisplayName("Cell Phone")]
        public string CellPhoneNumber { get; set; }

        [DisplayName("Home Phone")]
        public string HomePhoneNumber { get; set; }

        [DisplayName("Business Phone")]
        public string WorkPhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is required")]
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
       // [Required(ErrorMessage = "Donation Date is required")]
        [DisplayName("Donation Date *")]
        public string DonationDate { get; set; }

        public string CurrencyDonation { get; set; }

        public string ItemDonation { get; set; }

        public string ServiceDonation { get; set; }

    }

}

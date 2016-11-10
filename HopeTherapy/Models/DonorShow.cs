using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HopeTherapy.Models
{
    public class DonorShow
    {
        [Required(ErrorMessage = "First Name is required"), DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required"), DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Street Address is required"), DisplayName("Street Address")]
        public string StreetAddress { get; set; }

        [Required(ErrorMessage = "City is required"), DisplayName("City Name")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required"), DisplayName("State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Zip Code is required"), DisplayName("Zip Code")]
        public int ZipCode { get; set; }

        [Required(ErrorMessage = "County is required"), DisplayName("County")]
        public string County { get; set; }

        [Required(ErrorMessage = "Date of Birth is required"), DisplayName("Date of Birth")]
        public string Birthday { get; set; }

        public string Gender { get; set; }

        [DisplayName("Cell Phone")]
        public int CellPhoneNumber { get; set; }

        [DisplayName("Home Phone")]
        public int HomePhoneNumber { get; set; }

        [DisplayName("Business Phone")]
        public int OfficePhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is required"), DisplayName("Email")]
        public string EmailAddress { get; set; }

        public string CompanyName { get; set; }

        public string Position { get; set; }

        public string CompanyAddress { get; set; }

        public string CompanyCity { get; set; }

        public string CompanyState { get; set; }

        public int CompanyZip { get; set; }

    }
}
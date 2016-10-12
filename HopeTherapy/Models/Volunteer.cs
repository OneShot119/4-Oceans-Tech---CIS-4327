using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HopeTherapy.Models
{
    public class Volunteer
    {
        public int VolunterID { get; set; }

        [Required(ErrorMessage = "First Name is required"), DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required"), DisplayName("Last Name")]
        public string LastName { get; set; }

        public string Salutation { get; set; }

        [Required(ErrorMessage = "Street Address is required"), DisplayName("Street Address")]
        public string StreetAddress { get; set; }

        [Required(ErrorMessage = "City is required"), DisplayName("City Name")]
        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string County { get; set; }

        public string CellPhoneNumber { get; set; }

        public string HomePhoneNumber { get; set; }

        public string OfficePhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is required"), DisplayName("Email")]
        public string EmailAddress { get; set; }

        public string Birthday { get; set; }

        public string Gender { get; set; }

        public string CompanyName { get; set; }

        public string Position { get; set; }

        public string CompanyAddress { get; set; }

        public string VolunteerDays { get; set; }

        public string VolunteerPosition { get; set; }

    }
}
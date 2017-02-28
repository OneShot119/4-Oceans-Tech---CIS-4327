using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HopeTherapy.Models
{
    public class Volunteer
    {
        public int VolunteerID { get; set; }

        [DisplayName("First Name")]        //[Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        //[Required(ErrorMessage = "Last Name is required")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }


        //[Required(ErrorMessage = "Street Address is required")]
        [DisplayName("Address")]
        public string StreetAddress { get; set; }

        //[Required(ErrorMessage = "City is required")]
        [DisplayName("City")]
        public string City { get; set; }

        [DisplayName("State")]
        public string States { get; set; }
        public IEnumerable<SelectListItem> StatesList { get; set; }

        //[Required(ErrorMessage = "ZipCode is required")]
        [DisplayName("Zip Code")]
        public string ZipCode { get; set; }
        //[Required(ErrorMessage = "County is required")]
        public string County { get; set; }
        // [Required(ErrorMessage = "Cell Phone Number is required")]
        [DisplayName("Cell Phone Number")]
        public string CellPhoneNumber { get; set; }

        [DisplayName("Home Phone Number")]
        public string HomePhoneNumber { get; set; }

        [DisplayName("Work Phone Number")]
        public string WorkPhoneNumber { get; set; }

        //[DataType(DataType.EmailAddress)]
        //[Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        public string Birthday { get; set; }

        public string Gender { get; set; }

        [DisplayName("Company Name")]
        public string CompanyName { get; set; }

        public string Position { get; set; }

        [DisplayName("Company Address")]
        public string CompanyAddress { get; set; }

        [DisplayName("Company Zip")]
        public string CompanyZip { get; set; }

        [DisplayName("Orientation Date")]
        public string DateOrientation { get; set; }

        [DisplayName("Start Date")]
        public string DateStarted { get; set; }
        //        public string DaysVolunteered { get; set; }
        [DisplayName("Volunteer Hours/Month")]
        public string HoursPerMonth { get; set; }

        [DisplayName("Volunteer Position")]
        public string VolunteerPosition { get; set; }
        public IEnumerable<SelectListItem> VolunteerPositions { get; set; }

        [DisplayName("Area of Interest")]
        public string AreaOfInterest { get; set; }

        public string Skills { get; set; }

        public string Donor { get; set; }

        public string Board { get; set; }

        [DisplayName("Email List")]
        public string EmailList { get; set; }

        [DisplayName("Mailing List")]
        public string MailList { get; set; }
    }
}
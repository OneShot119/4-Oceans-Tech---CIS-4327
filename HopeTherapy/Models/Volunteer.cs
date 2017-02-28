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

        //[Required(ErrorMessage = "First Name is required"), DisplayName("First Name")]
        public string FirstName { get; set; }

        //[Required(ErrorMessage = "Last Name is required"), DisplayName("Last Name")]
        public string LastName { get; set; }


        //[Required(ErrorMessage = "Street Address is required"), DisplayName("Street Address")]
        public string StreetAddress { get; set; }

        //[Required(ErrorMessage = "City is required"), DisplayName("City Name")]
        public string City { get; set; }

        public string States { get; set; }
        public IEnumerable<SelectListItem> StatesList { get; set; }

        //[Required(ErrorMessage = "ZipCode is required"), DisplayName("ZipCode")]
        public string ZipCode { get; set; }
        //[Required(ErrorMessage = "County is required"), DisplayName("County")]
        public string County { get; set; }
       // [Required(ErrorMessage = "Cell Phone Number is required"), DisplayName("Cell Phone")]
        public string CellPhoneNumber { get; set; }
       
        public string HomePhoneNumber { get; set; }

        public string WorkPhoneNumber { get; set; }

        //[DataType(DataType.EmailAddress)]
        //[Required(ErrorMessage = "Email is required"), DisplayName("Email")]
        public string Email { get; set; }

  //      [DataType(DataType.Date)]
        public string Birthday { get; set; }

        //[DisplayName("Gender")]
        public string Gender { get; set; }

        public string Job { get; set; }
        public string DateOrientation { get; set; }
        public string DateStarted { get; set; }
//        public string DaysVolunteered { get; set; }
        public string HoursPerMonth { get; set; }

        public string CompanyName { get; set; }

        public string Position { get; set; }

        public string CompanyAddress { get; set; }

        public string VolunteerPosition { get; set; }
        public IEnumerable<SelectListItem> VolunteerPositions { get; set; }

        public string AreaOfInterest { get; set; }

        public string Skills { get; set; }

        public string Donor { get; set; }

        public string Board { get; set; }

        public string EmailList { get; set; }

        public string MailList { get; set; }
    }
}
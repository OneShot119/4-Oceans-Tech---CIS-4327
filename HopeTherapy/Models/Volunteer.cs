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

        [DisplayName("First Name *")]
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [DisplayName("Last Name *")]
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
        [Required(ErrorMessage = "County is required")]
        [DisplayName("County *")]
        public string County { get; set; }
        // [Required(ErrorMessage = "Cell Phone Number is required")]
        [DisplayName("Cell Phone Number")]
        public string CellPhoneNumber { get; set; }

        [DisplayName("Home Phone Number")]
        public string HomePhoneNumber { get; set; }

        [DisplayName("Work Phone Number")]
        public string WorkPhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is required")]
        [DisplayName("Email")]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Birthday is required")]
        [DisplayName("Birthday *")]
        public string Birthday { get; set; }

        [Required(ErrorMessage = "Gender *")]
        [DisplayName("Gender - Required")]
        public string Gender { get; set; }

        [DisplayName("Company Name")]
        public string CompanyName { get; set; }

        public string Position { get; set; }

        [DisplayName("Company Address")]
        public string CompanyAddress { get; set; }

        [DisplayName("Company Zip")]
        public string CompanyZip { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Orientation Date is required")]
        [DisplayName("Orientation *")]
        public string DateOrientation { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Orientation Date is required")]
        [DisplayName("Start Date *")]
        public string DateStarted { get; set; }

        [Required(ErrorMessage = "Hours Volunteered is required")]
        //[DisplayName("Volunteer Hours/Month - Required")]
        public int HoursPerMonth { get; set; }

        [DisplayName("Volunteer Position")]
        public string VolunteerPosition { get; set; }
        public IEnumerable<SelectListItem> VolunteerPositions { get; set; }

        [DisplayName("Area of Interest")]
        public string AreaOfInterest { get; set; }

        public string Skills { get; set; }

        [Required(ErrorMessage = "Donor is required")]
        [DisplayName("Donor? -*")]
        public string Donor { get; set; }

        [Required(ErrorMessage = "Board is required")]
        [DisplayName("Board? *")]
        public string Board { get; set; }

        [Required(ErrorMessage = "Email List is required")]
        [DisplayName("Email List? *")]
        public string EmailList { get; set; }

        [Required(ErrorMessage = "Mail List is required")]
        [DisplayName("Mail List? *")]
        public string MailList { get; set; }
        public Boolean Active { get; set; }


        public Boolean Sunday { get; set; } = false;
        public Boolean Monday { get; set; } = false;
        public Boolean Tuesday { get; set; } = false;
        public Boolean Wednesday { get; set; } = false;
        public Boolean Thursday { get; set; } = false;
        public Boolean Friday { get; set; } = false;
        public Boolean Saturday { get; set; } = false;
        //Need collection of these ^ 
        public List<String> Schedule()
        {
            List<String> schedule = new List<String>();
            if (Sunday) { schedule.Add("Sunday"); }
            if (Monday) { schedule.Add("Monday"); }
            if (Tuesday) { schedule.Add("Tuesday"); }
            if (Wednesday) { schedule.Add("Wednesday"); }
            if (Thursday) { schedule.Add("Thursday"); }
            if (Friday) { schedule.Add("Friday"); }
            if (Saturday) { schedule.Add("Saturday"); }
            return schedule;
        }
    
    }
}
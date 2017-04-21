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
        private DateTime _date = DateTime.Now;


        public int VolunteerID { get; set; }

        [DisplayName("First Name ")]
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [DisplayName("Last Name ")]
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
        [DisplayName("County ")]
        public string County { get; set; }

        // [Required(ErrorMessage = "Cell Phone Number is required")]
        [DisplayName("Cell Phone Number")]
        public string CellPhoneNumber { get; set; }

        [DisplayName("Home Phone Number")]
        public string HomePhoneNumber { get; set; }

        [DisplayName("Work Phone Number")]
        public string WorkPhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        // [Required(ErrorMessage = "Email is required")]
        [DisplayName("Email")]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Birthday is required")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Birthday ")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [DisplayName("Gender ")]
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
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Orientation ")]
        public DateTime DateOrientation { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Start Date is required")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Start Date ")]
        public DateTime DateStarted { get; set; }

        //[Required(ErrorMessage = "Hours Volunteered is required")]
        [DisplayName("Volunteer Hours/Month")]
        public int HoursPerMonth { get; set; }

        [DisplayName("Volunteer Position")]
        public string VolunteerPosition { get; set; }
        public IEnumerable<SelectListItem> VolunteerPositions { get; set; }

        [DisplayName("Area of Interest")]
        public string AreaOfInterest { get; set; }

        public string Skills { get; set; }

        [Required(ErrorMessage = "Donor is required")]
        [DisplayName("Donor? ")]
        public string Donor { get; set; }

        [Required(ErrorMessage = "Board is required")]
        [DisplayName("Board? ")]
        public string Board { get; set; }

        [Required(ErrorMessage = "Email List is required")]
        [DisplayName("Email List? ")]
        public string EmailList { get; set; }

        [Required(ErrorMessage = "Mail List is required")]
        [DisplayName("Mail List? ")]
        public string MailList { get; set; }
        public Boolean Active { get; set; }


        public Boolean Sunday { get; set; }
        public Boolean Monday { get; set; }
        public Boolean Tuesday { get; set; }
        public Boolean Wednesday { get; set; }
        public Boolean Thursday { get; set; }
        public Boolean Friday { get; set; }
        public Boolean Saturday { get; set; }
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
        public IEnumerable<String> dayList { get; set; }
        public void setDays()
        {
            foreach(var day in dayList)
            {
                if (day=="Sunday") { this.Sunday=true; }
                if (day == "Monday") { this.Monday = true; }
                if (day == "Tuesday") { this.Tuesday = true; }
                if (day == "Wednesday") { this.Wednesday = true; }
                if (day == "Thursday") { this.Thursday = true; }
                if (day == "Friday") { this.Friday = true; }
                if (day == "Saturday") { this.Saturday = true; }

            }
        }
        public int dayNum(String day)
        {
            int daynum;
            switch (day)
            {
                case "Sunday":
                    daynum = 1;
                    break;
                case "Saturday":
                    daynum = 7;
                    break;
                case "Monday":
                    daynum = 2;
                    break;
                case "Tuesday":
                    daynum = 3;
                    break;
                case "Wednesday":
                    daynum = 4;
                    break;
                case "Thursday":
                    daynum = 5;
                    break;
                case "Friday":
                    daynum = 6;
                    break;
                default:
                    daynum = 0;
                    break;
            }
            return daynum;
        }
    }
}
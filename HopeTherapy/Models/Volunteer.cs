using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HopeTherapy.Models
{
    public class Volunteer
    {
        public int VolunterID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Salutation { get; set; }

        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string County { get; set; }

        public string CellPhoneNumber { get; set; }

        public string HomePhoneNumber { get; set; }

        public string OfficePhoneNumber { get; set; }

        public EmailService Email { get; set; }

        public string Birthday { get; set; }

        public string Gender { get; set; }

        public string CompanyName { get; set; }

        public string Position { get; set; }

        public string CompanyAddress { get; set; }

        public string VolunteerDays { get; set; }

        public string VolunteerPosition { get; set; }

    }
}
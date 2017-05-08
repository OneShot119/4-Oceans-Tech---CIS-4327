using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HopeTherapy.Models
{
    public class Donation
    {
        public int donorID { get; set; }
        public String donorFName { get; set; }
        public String donorLName { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }

        public string donationItem { get; set; }

        public int donationAmount { get; set; }

    }
}
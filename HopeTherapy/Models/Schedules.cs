using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HopeTherapy.Models
{
    public class Schedules
    {
        public Boolean Sunday { get; set; } = false;
        public Boolean Monday { get; set; } = false;
        public Boolean Tuesday { get; set; } = false;
        public Boolean Wednesday { get; set; } = false;
        public Boolean Thursday { get; set; } = false;
        public Boolean Friday { get; set; } = false;
        public Boolean Saturday { get; set; } = false;

        //I WANNA DO A HASHTABLE MAYBE?
        //{KEY DAY -------- VALUE BOOLEAN}

    }
}
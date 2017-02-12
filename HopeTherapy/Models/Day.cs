using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HopeTherapy.Models
{
    public class Day
    {
        public String fname { get; set; }

        public String lname { get; set; }

        public String day { get; set; }

        public int dayNum()
        {
            int daynum=0;
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
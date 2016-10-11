using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HopeTherapy.Models
{
    public class Login
    {
        [DisplayName("Username")]
        [Required(ErrorMessage = "Username is required"), MaxLength(50, ErrorMessage = "Username must be less than 50 chars")]
        public string Username { get; set; }
        [DisplayName("Password")]
        [Required(ErrorMessage = "Password is required"), MaxLength(50, ErrorMessage = "Password must be less than 50 chars")]
        public string Password { get; set; }

        
    }
}
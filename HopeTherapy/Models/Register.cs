using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HopeTherapy.Models
{
    public class Register
    {
        [Required(ErrorMessage = "Username is required"), MaxLength(50, ErrorMessage = "Username must be less than 50 chars"), DisplayName("Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required"), MaxLength(50, ErrorMessage = "Password must be less than 50 chars"), DisplayName("Password"), DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is required"), EmailAddress(ErrorMessage = "Invalid email address."), DisplayName("Email"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "FirstName is required"), DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required"), DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "AccessKey is required"), DisplayName("Access Key")]
        public string AccessKey { get; set; }

    }
}
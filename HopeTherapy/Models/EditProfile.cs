using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HopeTherapy.Models
{
    public class EdiProfile
    {
        [Required(ErrorMessage = "Username is required"), MaxLength(50, ErrorMessage = "Username must be less than 50 chars"), DisplayName("Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required"), MaxLength(50, ErrorMessage = "Password must be less than 50 chars"), DisplayName("Password"), DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is required"), MaxLength(50, ErrorMessage = "Email must be less than 50 chars"), EmailAddress(ErrorMessage = "Invalid email address."), DisplayName("Email"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "FirstName is required"), MaxLength(50, ErrorMessage = "First Name must be less than 50 chars"), DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required"), MaxLength(50, ErrorMessage = "Last Name must be less than 50 chars"), DisplayName("Last Name")]
        public string LastName { get; set; }
    }
}
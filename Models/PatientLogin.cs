using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCprojectHealthCare.Models
{
    public class PatientLogin
    {
        [Required(ErrorMessage = "Please enter your email")]
        [Display(Name = "Enter email: ")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your password")]
        [Display(Name = "Enter password: ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
    
}
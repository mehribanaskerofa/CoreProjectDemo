using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProjectDemo.Models
{
    public class UserSignUpModel
    {
        [Display(Name = "Name & Surname")]
        [Required(ErrorMessage = "Please enter name and surname")]
        public string NameSurname { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }

        [Display(Name = "Password Repeat")]
        [Compare("Password", ErrorMessage = "Passwords do not match!")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please enter e-mail")]
        public string Mail { get; set; }

        [Display(Name = "User name")]
        [Required(ErrorMessage = "Please enter your username")]
        public string UserName { get; set; }
        public bool TermsOfUse { get; set; }

    }
}

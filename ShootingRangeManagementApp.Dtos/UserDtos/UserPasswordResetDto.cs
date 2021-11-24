using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingRangeManagementApp.Dtos.UserDtos
{
    public class UserPasswordResetDto
    {
        [Required]
        [EmailAddress]
        public string Email{ get; set; }
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string Password { get; set; }
        [Display(Name ="Confirm Password")]
        [Compare("Password",ErrorMessage ="Passwords does not match.")]
        public string ConfirmPassword { get; set; }
       
    }
}

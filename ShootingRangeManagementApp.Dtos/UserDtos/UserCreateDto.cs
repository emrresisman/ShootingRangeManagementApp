using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingRangeManagementApp.Dtos.UserDtos
{
    public class UserCreateDto
    {
        [Required(ErrorMessage="Username is required.")]
        public string Username { get; set; }
        [EmailAddress(ErrorMessage ="Please enter a valid email address.")]
        [Required(ErrorMessage ="Email address is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password is required.")]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="Passwords does not match.")]
        public string ConfirmPassword { get; set; }

    }
}

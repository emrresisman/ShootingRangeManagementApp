using ShootingRangeManagementApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingRangeManagementApp.Dtos.UserDtos
{
    public class UserAdminCreateDto
    {

        [Required(ErrorMessage ="Username is required.")]
        public string Username { get; set; }
        [Required(ErrorMessage ="Email is required.")]
        public string Email { get; set; }
       
    }
  
}

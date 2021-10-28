using ShootingRangeManagementApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingRangeManagementApp.Models.Entities
{
    public class AppUser: BaseEntity
    {
        public string FullName { get; set; }
        public string Username { get; set; }
     
        public string Password { get; set; }
       
        public AppRole AppRole { get; set; }

    }
}

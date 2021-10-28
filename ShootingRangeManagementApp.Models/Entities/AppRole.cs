using ShootingRangeManagementApp.Models;
using ShootingRangeManagementApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingRangeManagementApp.Models.Entities
{
    public class AppRole: BaseEntity
    {
        public string Definition { get; set; }
        
        public List<AppUser> AppUsers { get; set; }
    }
}

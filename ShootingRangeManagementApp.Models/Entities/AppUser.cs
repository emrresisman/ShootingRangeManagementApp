using Microsoft.AspNetCore.Identity;
using ShootingRangeManagementApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingRangeManagementApp.Models.Entities
{
    public class AppUser: IdentityUser<int>
    {

        [ForeignKey("Store")]
        //public int? StoreId { get; set; }
        public int? StoreId { get; set; }
        public virtual Store Store { get; set; }
        //public string FullName { get; set; }
        //public string Username { get; set; }

        //public string Password { get; set; }

        
        public virtual List<AppUserStore> AppUserStores { get; set; }
       

    }
}

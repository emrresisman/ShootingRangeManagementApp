using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingRangeManagementApp.Models.Entities
{
    public class StoreAdminStores
    { 
        [ForeignKey("Store")]
        public virtual List<Store> Stores { get; set; }
        public int StoreId { get; set; }

        [ForeignKey("AppUser")]
        public virtual AppUser AppUser { get; set; }
        public int UserId { get; set; }
         
    }
}

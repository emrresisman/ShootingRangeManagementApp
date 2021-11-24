using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingRangeManagementApp.Models.Entities
{
    public class StoreStocks:BaseEntity
    {
        public StoreStocks()
        {
            WorkingGunCount = 0;
            BrokenGunCount = 0;
            BulletBoxCount = 0;
        }
        [ForeignKey("Store")]
        public int StoreId { get; set; }
        public virtual Store Store { get; set; }
        public int WorkingGunCount { get; set; } 
        public int BrokenGunCount { get; set; } 
        public int BulletBoxCount { get; set; } 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingRangeManagementApp.Models.Entities
{
    public class AppUserStore : BaseEntity
    {
        public int AppUserId { get; set; }
        public int StoreId { get; set; }
    }
}

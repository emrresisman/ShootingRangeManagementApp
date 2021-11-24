using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingRangeManagementApp.Models.Entities { 
    public class Store 
    {
        public int StoreId { get; set; }

        [MaxLength(50)]
        public string StoreName { get; set; }
        public string Balance { get; set; }
        public string Address { get; set; }
        public virtual List<DailyStoreGiro> DailyStoreGiro { get; set; }
        public virtual List<MonthlyStoreGiro> MonthlyStoreGiro { get; set; }
        public virtual List<StorePartner> StorePartners { get; set; }
        public virtual StoreStocks StoreStocks { get; set; }
        public virtual List<Bills> Bills { get; set; }
        public virtual List<AppUser> AppUsers { get; set; }

    }
}

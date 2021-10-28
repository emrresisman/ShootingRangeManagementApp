using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingRangeManagementApp.Models.Entities { 
    public class MonthlyStoreGiro : BaseEntity
    {
        [ForeignKey("Store")]
        public int StoreId { get; set; }
        public virtual Store Store { get; set; }
        public int TotalAmountMonthly { get; set; }
        public DateTime Date { get; set; }
        
    }
}

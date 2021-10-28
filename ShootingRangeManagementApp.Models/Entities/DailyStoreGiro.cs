using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingRangeManagementApp.Models.Entities
{
    public class DailyStoreGiro : BaseEntity
    {
        [ForeignKey("Store")]
        public int StoreId { get; set; }
        public virtual Store Store { get; set; }
        
        
        public int TotalAmountDaily { get; set; }
        public DateTime Date { get; set; }
        public string Image { get; set; }
    }
}

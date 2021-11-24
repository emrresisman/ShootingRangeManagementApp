using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingRangeManagementApp.Models.Entities
{
    public class Bills: BaseEntity
    {
        [ForeignKey("Store")]
        public int StoreId { get; set; }
        public virtual Store Store { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Explanation { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal BillCost { get; set; }
        
    }
}

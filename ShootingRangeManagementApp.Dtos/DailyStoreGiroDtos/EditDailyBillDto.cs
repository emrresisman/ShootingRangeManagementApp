using ShootingRangeManagementApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingRangeManagementApp.Dtos.DailyStoreGiroDtos
{
    public class EditDailyBillDto
    {

        [ForeignKey("Store")]
        public int StoreId { get; set; }
        public virtual Store Store { get; set; }
       
        public string Name { get; set; }
        public string Explanation { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal BillCost { get; set; }
    }
}

using Microsoft.AspNetCore.Http;
using ShootingRangeManagementApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingRangeManagementApp.Dtos.DailyStoreGiroDtos
{
    public class EditDailyStoreGiroDto
    {
        [ForeignKey("Store")]
        public int StoreId { get; set; }
        public virtual Store Store { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal Cash { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal CreditCart { get; set; }
       
       
       
    }
}

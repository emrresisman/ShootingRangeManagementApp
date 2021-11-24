using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [Column(TypeName = "decimal(18, 4)")]
        public decimal Cash { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal CreditCart { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        [DisplayName("Image")]
        public string ImageName { get; set; }
        [NotMapped]
        [DisplayName("Upload Image")]
        public IFormFile Image { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingRangeManagementApp.Dtos.StorePartnerDtos
{
    public class EditStorePartnerDto
    {
        public int Id { get; set; }
        [ForeignKey("Store")]
        public int StoreId { get; set; }
        public string Name { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal PaymentRate { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal TotalAmount { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingRangeManagementApp.Dtos.StorePartnerDtos
{
    public class CreateStorePartnerDto
    {
        [ForeignKey("Store")]
        public int StoreId { get; set; }
        public string Name { get; set; }
        public int PaymentRate { get; set; }
        public int TotalAmount { get; set; }
    }
}

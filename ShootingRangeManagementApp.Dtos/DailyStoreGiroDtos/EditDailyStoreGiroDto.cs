using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingRangeManagementApp.Dtos.DailyStoreGiroDtos
{
    public class EditDailyStoreGiroDto
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public float Cash { get; set; }
        public float CreditCart { get; set; }
        public string ImageName { get; set; }
        [NotMapped]
        [DisplayName("Upload Image")]
        public IFormFile Image { get; set; }
    }
}

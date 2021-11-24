using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingRangeManagementApp.Dtos.StoreDtos
{
    public class EditStoreDto
    {
        public int Id { get; set; }
        public int StoreId { get;set; }
        public string StoreName { get; set; }
        public string Balance { get; set; }
        public string Address { get; set; }
    }
}

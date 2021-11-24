using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingRangeManagementApp.Dtos.UserDtos
{
    public class StoreAssignListDto
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public bool Exist { get; set; }

    }
    public class StoreAssignSendDto
    {
        
        public List<StoreAssignListDto> Store { get; set; }
        public int UserId { get; set; }
        public int StoreId { get; set; }

    }
}

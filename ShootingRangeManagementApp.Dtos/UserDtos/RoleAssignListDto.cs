using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingRangeManagementApp.Dtos.UserDtos
{
    public class RoleAssignListDto
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public bool Exist { get; set; }
    }
    public class RoleAssignSendDto
    {
        public List<RoleAssignListDto> Roles { get; set; }
        public int UserId { get; set; }

    }
}

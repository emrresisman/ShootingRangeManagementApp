using ShootingRangeManagementApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingRangeManagementApp.Core.UsersRepository
{
    public interface IUserRepository
    {
        public void AddStoreToUser(int id,Store store);
        public AppUser GetById(int id);
       

    }
}

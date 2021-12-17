using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShootingRangeManagementApp.Core.Repositories;
using ShootingRangeManagementApp.EFCore.Context;
using ShootingRangeManagementApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingRangeManagementApp.Core.UsersRepository
{
    public class UserRepository :Repository<AppUser>, IUserRepository
    {
        
        private readonly UserManager<AppUser> _userManager;
        
        public UserRepository(StoreContext context, UserManager<AppUser> userManager) : base(context)
        {

            _userManager = userManager;
          
        }

       

        public void AddStoreToUser(int id, Store store)
        {

            
            var user = GetById(id);
            //user.Stores.Add(store);
            
            
        }
        public AppUser GetById(int id)
        {
            return _userManager.Users.SingleOrDefault(x => x.Id == id);
        }
    }
}

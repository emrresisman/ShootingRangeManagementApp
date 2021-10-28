using ShootingRangeManagementApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingRangeManagementApp.Core.Interfaces
{
    public interface IStoreRepository
    {

        IEnumerable<Store> GetStores();
        public void Create(Store store);
        public void Delete(int id);
        public void EditStore(Store store);
        public Store GetStore(int id);
    }
}

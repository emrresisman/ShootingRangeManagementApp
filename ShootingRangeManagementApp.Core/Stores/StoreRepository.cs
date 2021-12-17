using ShootingRangeManagementApp.Core.Interfaces;
using ShootingRangeManagementApp.Core.Repositories;
using ShootingRangeManagementApp.EFCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShootingRangeManagementApp.Models;
using ShootingRangeManagementApp.Models.Entities;

namespace ShootingRangeManagementApp.Core.Stores
{
    public class StoreRepository : Repository<Store>, IStoreRepository
    {
        public StoreRepository(StoreContext context):base(context)
        {

        }
        public void Create(Store store)
        {
            Add(store);
        }

        public void Delete(int id)
        {
            Remove(id);
        }

        public void EditStore(Store store)
        {
            Update(store);
        }

        public Store GetStore(int id)
        {
            return GetById(id);
        }

        public IEnumerable<Store> GetStores()
        {
            return GetAll();
        }
        public IEnumerable<Store> GetStoresWithFilter(int id)
        {
            return Find(x => x.StoreId == id).ToList();
        }
        public IEnumerable<Store> GetStoresWithFilterMultiple(List<int> ids)
        {

            return Find(o => ids.Any(f => f == o.StoreId));
        }
    }
}

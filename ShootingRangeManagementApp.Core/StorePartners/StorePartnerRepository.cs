using ShootingRangeManagementApp.Core.Repositories;
using ShootingRangeManagementApp.EFCore.Context;
using ShootingRangeManagementApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingRangeManagementApp.Core.StorePartners
{
    public class StorePartnerRepository : Repository<StorePartner>, IStorePartnerRepository
    {
        public StorePartnerRepository(StoreContext context) : base(context)
        {

        }
        public void Create(StorePartner storePartner)
        {
            Add(storePartner);
        }

        public void Delete(int id)
        {
            Remove(id);
        }

        public void EditStorePartner(StorePartner storePartner)
        {
            Update(storePartner);
        }

        public StorePartner GetStorePartner(int id)
        {
            return GetById(id);
        }
        public IEnumerable<StorePartner> FindStorePartners(int id)
        {
            return Find(x => x.StoreId == id).ToList();
        }
        public IEnumerable<StorePartner> GetStorePartners()
        {
            return GetAll();
        }

      
    }
}

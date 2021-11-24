using ShootingRangeManagementApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingRangeManagementApp.Core.StorePartners
{
    public interface IStorePartnerRepository
    {
        IEnumerable<StorePartner> GetStorePartners();
        public IEnumerable<StorePartner> FindStorePartners(int id);
        public void Create(StorePartner storePartner);
        public void Delete(int id);
        public void EditStorePartner(StorePartner storePartner);
        public StorePartner GetStorePartner(int id);
    }
}

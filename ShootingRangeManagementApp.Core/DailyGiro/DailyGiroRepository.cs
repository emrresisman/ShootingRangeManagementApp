using ShootingRangeManagementApp.Core.Repositories;
using ShootingRangeManagementApp.EFCore.Context;
using ShootingRangeManagementApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingRangeManagementApp.Core.DailyGiro
{
    public class DailyGiroRepository : Repository<DailyStoreGiro>, IDailyGiroRepository
    {
        public DailyGiroRepository(StoreContext context) : base(context)
        {

        }

        public void Create(DailyStoreGiro dailyStoreGiro)
        {
            Add(dailyStoreGiro);
        }

        public void Delete(int id)
        {
            Remove(id);
        }

        public void EditDailyGiro(DailyStoreGiro dailyStoreGiro)
        {
            throw new NotImplementedException();
        }

        public DailyStoreGiro GetDailyGiro(int id)
        {
            return GetById(id);
        }

        public IEnumerable<DailyStoreGiro> GetDailyGiros()
        {
            return GetAll();
        }
    }
}

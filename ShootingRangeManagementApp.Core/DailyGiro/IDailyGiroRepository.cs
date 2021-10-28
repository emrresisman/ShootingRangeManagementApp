using ShootingRangeManagementApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingRangeManagementApp.Core.DailyGiro
{
    public interface IDailyGiroRepository
    {
        IEnumerable<DailyStoreGiro> GetDailyGiros();
        public void Create(DailyStoreGiro dailyStoreGiro);
        public void Delete(int id);
        public void EditDailyGiro(DailyStoreGiro dailyStoreGiro);
        public DailyStoreGiro GetDailyGiro(int id);
    }
}

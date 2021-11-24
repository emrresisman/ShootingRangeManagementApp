using ShootingRangeManagementApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingRangeManagementApp.Core.MonthlyGiroRepository
{
    public interface IMonthlyGiroRepository
    {
        IEnumerable<MonthlyStoreGiro> GetMonthlyGiros();
        public void Create(MonthlyStoreGiro monthlyStoreGiro);
        public void Delete(int id);
        public void EditDailyGiro(MonthlyStoreGiro monthlyStoreGiro);
        public MonthlyStoreGiro GetDailyGiro(int id);
    }
}

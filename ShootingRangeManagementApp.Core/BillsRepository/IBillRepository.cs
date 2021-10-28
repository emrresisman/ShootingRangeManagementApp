using System;
using ShootingRangeManagementApp.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingRangeManagementApp.Core.BillsRepository
{
    public interface IBillRepository
    {
        IEnumerable<Bills> GetDailyBills();
        public void Create(Bills bills);
        public void Delete(int id);
        public void EditBill(Bills bills);
        public Bills GetBill(int id);
    }
}

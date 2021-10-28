using ShootingRangeManagementApp.Core.Repositories;
using ShootingRangeManagementApp.EFCore.Context;
using ShootingRangeManagementApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingRangeManagementApp.Core.BillsRepository
{
    public class BillRepository : Repository<Bills>, IBillRepository
    {
        public BillRepository(StoreContext context) : base(context)
        {

        }
        public void Create(Bills bills)
        {
            Add(bills);
        }

        public void Delete(int id)
        {
            Remove(id);
        }

        public void EditBill(Bills bills)
        {
            throw new NotImplementedException();
        }

        public Bills GetBill(int id)
        {
            return GetById(id);
        }

        public IEnumerable<Bills> GetDailyBills()
        {
            return GetAll();
        }
    }
}

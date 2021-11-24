using ShootingRangeManagementApp.Core.Repositories;
using ShootingRangeManagementApp.EFCore.Context;
using ShootingRangeManagementApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingRangeManagementApp.Core.StocksRepository
{
    public class StockRepository : Repository<StoreStocks>, IStockRepository
    {
        public StockRepository(StoreContext context) : base(context)
        {

        }
        public void Create(StoreStocks storeStocks)
        {
            Add(storeStocks);
        }

        public void Delete(int id)
        {
            Remove(id);
        }

        public void EditStocks(StoreStocks storeStocks)
        {
            Update(storeStocks);
        }

        public StoreStocks GetStock(int id)
        {
            return GetById(id);
        }

        public IEnumerable<StoreStocks> GetStocks()
        {
            return GetAll();
        }
    }
}

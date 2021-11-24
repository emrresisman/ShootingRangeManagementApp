using ShootingRangeManagementApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingRangeManagementApp.Core.StocksRepository
{
    public interface IStockRepository
    {
    IEnumerable<StoreStocks> GetStocks();
    public void Create(StoreStocks storeStocks);
    public void Delete(int id);
    public void EditStocks(StoreStocks storeStocks);
    public StoreStocks GetStock(int id);
}
}

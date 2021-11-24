using ShootingRangeManagementApp.Core.BillsRepository;
using ShootingRangeManagementApp.Core.DailyGiro;
using ShootingRangeManagementApp.Core.Interfaces;
using ShootingRangeManagementApp.Core.StocksRepository;
using ShootingRangeManagementApp.Core.StorePartners;
using ShootingRangeManagementApp.Core.Stores;
using ShootingRangeManagementApp.EFCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingRangeManagementApp.Core.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        private StoreContext _storeContext;
        public UnitOfWork(StoreContext storeContext, IStoreRepository storeRepository,IDailyGiroRepository dailyGiroRepository,IStockRepository stockRepository,IBillRepository billRepository,IStorePartnerRepository storePartnerRepository)
        {
            StockRepository = stockRepository;
            StoreRepository = storeRepository;
            DailyGiroRepository = dailyGiroRepository;
            BillRepository = billRepository;
            StorePartnerRepository = storePartnerRepository;
            _storeContext = storeContext;
        }
        public IStorePartnerRepository StorePartnerRepository { get; private set; }
        public IBillRepository BillRepository { get; private set; }
        public IStockRepository StockRepository { get; private set; }
        public IStoreRepository StoreRepository { get; private set; }
        public IDailyGiroRepository DailyGiroRepository { get; private set; }

        public int Complete()
        {
            return _storeContext.SaveChanges();
        }

        public void Dispose()
        {
            _storeContext.Dispose();
        }
    }
}

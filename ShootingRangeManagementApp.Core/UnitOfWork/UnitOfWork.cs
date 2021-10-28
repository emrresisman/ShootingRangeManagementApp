using ShootingRangeManagementApp.Core.Interfaces;
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
        public UnitOfWork(StoreContext storeContext, IStoreRepository storeRepository)
        {
            StoreRepository = storeRepository;
            _storeContext = storeContext;
        }

        public IStoreRepository StoreRepository { get; private set; }

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

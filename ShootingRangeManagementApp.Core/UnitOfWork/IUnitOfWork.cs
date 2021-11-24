using ShootingRangeManagementApp.Core.BillsRepository;
using ShootingRangeManagementApp.Core.DailyGiro;
using ShootingRangeManagementApp.Core.Interfaces;
using ShootingRangeManagementApp.Core.StorePartners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingRangeManagementApp.Core.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        IStoreRepository StoreRepository { get; }
        IBillRepository BillRepository { get; }
        IDailyGiroRepository DailyGiroRepository { get; }
        IStorePartnerRepository StorePartnerRepository { get; }

        int Complete();
    }
}

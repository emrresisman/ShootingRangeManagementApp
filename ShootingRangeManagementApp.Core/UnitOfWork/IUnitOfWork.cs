using ShootingRangeManagementApp.Core.Interfaces;
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
        int Complete();
    }
}

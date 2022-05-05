using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Repository;

namespace WebApplication1.UnitOfWork
{
    public interface IUnitOfWork
    {
        IWarehouseRepository WarehouseRepository { get; }
        void Commit();
    }
}

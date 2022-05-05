using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Repository;

namespace WebApplication1.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IWarehouseRepository _warehouseRepository;
        private WarehouseDbContext _dbContext;
        public UnitOfWork(WarehouseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IWarehouseRepository WarehouseRepository
        {
            get
            {
                return _warehouseRepository ??
                    (_warehouseRepository = new WarehouseRepository(_dbContext));
            }
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}

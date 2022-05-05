using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DomainModel;

namespace WebApplication1.Repository
{
    public interface IWarehouseRepository : IDisposable
    {
        ResponseData GetCarsByDateAddedAsc(int page, int pageSize);

        CarDetails GetCarDetails(int vehicleId);
    }
}

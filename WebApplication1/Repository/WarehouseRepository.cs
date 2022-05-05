using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Data;
using WebApplication1.DomainModel;
using WebApplication1.Extensions;

namespace WebApplication1.Repository
{
    public class WarehouseRepository : IWarehouseRepository
    {

        private readonly WarehouseDbContext _context;

        private bool disposed = false;
        public WarehouseRepository(WarehouseDbContext context)
        {
            _context = context;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public ResponseData GetCarsByDateAddedAsc(int page, int pageSize)
        {
            try
            {
                var result = (from w in _context.Warehouse
                              join c in _context.Car
                              on w.Id equals c.WarehouseId
                              join v in _context.Vehicle
                              on c.Id equals v.CarID

                              select new CarData
                              {
                                  VehicleId = v.Id,
                                  Make = v.Make,
                                  Model = v.Model,
                                  YearModel = v.YearModel,
                                  Price = v.Price,
                                  DateAdded = v.DateAdded,
                                  Licensed = v.Licensed
                              }).OrderBy(x => x.DateAdded);

                var cars = result.GetPaged(page, pageSize).Results.ToList();

                return new ResponseData
                {
                    Car = cars,
                    CollectionSize = result.ToList().Count
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CarDetails GetCarDetails(int vehicleId)
        {
            try
            {
                var result = (from w in _context.Warehouse
                              join c in _context.Car
                              on w.Id equals c.WarehouseId
                              join l in _context.Location
                             on w.Id equals l.WarehouseId
                              join v in _context.Vehicle
                              on c.Id equals v.CarID
                              where v.Id == vehicleId
                              select new CarDetails
                              {
                                  Lat = l.Lat,
                                  Lng = l.Long,
                                  Location = c.Location,
                                  WarehouseName = w.Name,
                                  Make = v.Make,
                                  Model = v.Model,
                                  YearModel = v.YearModel
                              });

                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.DomainModel
{
    public class CarDetails
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int YearModel { get; set; }
        public string Location { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string WarehouseName { get; set; }
    }
}

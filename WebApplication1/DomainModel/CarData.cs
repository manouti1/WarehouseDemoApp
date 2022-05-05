using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.DomainModel
{
    public class CarData
    {
        public int VehicleId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int YearModel { get; set; }
        public double Price { get; set; }
        public bool Licensed { get; set; }
        public DateTime DateAdded { get; set; }
    }
}

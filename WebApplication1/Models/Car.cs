using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Car
    {
        [JsonConstructor]
        public Car(
            string location,
            List<Vehicle> vehicles
        )
        {
            this.Location = location;
            this.Vehicles = vehicles;
        }
        public Car() { }
        public string Location { get; set; }

        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [ForeignKey("Warehouse")]
        public string WarehouseId { get; set; }
   
        public List<Vehicle> Vehicles { get; set; }

    }

}

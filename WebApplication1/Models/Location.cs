using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Location
    {
        [JsonConstructor]
        public Location(
            string lat,
            string @long
        )
        {
            this.Lat = Double.Parse(lat);
            this.Long = Double.Parse(@long);
        }
        public Location() { }
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey("Warehouse")]
        public string WarehouseId { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
    }
}


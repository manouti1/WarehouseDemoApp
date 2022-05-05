using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Warehouse
    {
        [JsonConstructor]
        public Warehouse(
            string _id,
            string name,
            Location location,
            Car cars
        )
        {
            this.Id = _id;
            this.Name = name;
            this.Location = location;
            this.Cars = cars;
        }
        public Warehouse() { }
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
        public Car Cars { get; set; }
    }
}

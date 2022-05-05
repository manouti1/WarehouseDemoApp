using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Vehicle
    {
        [JsonConstructor]
        public Vehicle(
            int _id,
            string make,
            string model,
            int year_Model,
            double price,
            bool licensed,
            DateTime date_Added
        )
        {
            this.Id = _id;
            this.Make = make;
            this.Model = model;
            this.YearModel = year_Model;
            this.Price = price;
            this.Licensed = licensed;
            this.DateAdded = date_Added;
        }
        public Vehicle() { }
        [Key]
        public int Id { get; set; }
        [ForeignKey("Car")]
        public string CarID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int YearModel { get; set; }
        public double Price { get; set; }
        public bool Licensed { get; set; }
        public DateTime DateAdded { get; set; }
    }
}

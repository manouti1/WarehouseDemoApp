using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class WarehouseDbContext : DbContext
    {
        public WarehouseDbContext()
        {

        }
        public WarehouseDbContext(DbContextOptions<WarehouseDbContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
      
        //entities
        public DbSet<Warehouse> Warehouse { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Car> Car { get; set; }

    }
}

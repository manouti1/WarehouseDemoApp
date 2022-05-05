using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class Seeder
    {
        public static void Seed(string jsonData,
                           IServiceProvider serviceProvider)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ContractResolver = new PrivateSetterContractResolver()
            };
            List<Warehouse> warehouse =
             JsonConvert.DeserializeObject<List<Warehouse>>(
               jsonData, settings);
            using var serviceScope = serviceProvider
               .GetRequiredService<IServiceScopeFactory>()
               .CreateScope();
            var context = serviceScope
                          .ServiceProvider.GetService<WarehouseDbContext>();

            if (!context.Warehouse.Any())
            {
                context.AddRange(warehouse);
                context.SaveChanges();
            }
        }
    }
}

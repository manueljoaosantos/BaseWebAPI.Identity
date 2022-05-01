using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class BaseDbContextSeed
    {
        public static async Task SeedAsync(BaseDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                //var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                if (!context.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                    //var typesData = File.ReadAllText(path + @"/Data/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    foreach (var item in types)
                    {
                        context.ProductTypes.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Products.Any())
                {
                    //var productsData = File.ReadAllText(path + @"/Data/SeedData/products.json");
                    var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    foreach (var item in products)
                    {
                        context.Products.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
                
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<BaseDbContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}

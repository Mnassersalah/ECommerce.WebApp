using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Skinet.Core.Entities;
using System.Text.Json;

namespace Skinet.Infrastructure.Data.DataSeed
{
    public static class DataSeed
    {
        public static async Task SeedDataAsync(DbContext dbContext, ILogger logger)
        {
            try
            {
                await SeedTableAsync<ProductBrand>(dbContext, "../Skinet.Infrastructure/Data/DataSeed/brands.json");
                await SeedTableAsync<ProductType>(dbContext, "../Skinet.Infrastructure/Data/DataSeed/types.json");
                await SeedTableAsync<Product>(dbContext, "../Skinet.Infrastructure/Data/DataSeed/products.json");
            }
            catch (Exception ex)
            {

                logger.LogError(ex, "Error while Data seeding..");
            }
        }

        private static async Task SeedTableAsync<T>(DbContext dbContext, string jsonFilePath) 
            where T : class
        {
            if (dbContext.Set<T>().Any())
                return;

            var textData = await File.ReadAllTextAsync(jsonFilePath);

            var items = JsonSerializer.Deserialize<List<T>>(textData);

            foreach (var item in items)
            {
                dbContext.Add(item);
            }
            await dbContext.SaveChangesAsync();
        }
    }
}

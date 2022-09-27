using catalog.api.Models;
using MongoDB.Driver;

namespace catalog.api.Database
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configration)
        {
            var client = new MongoClient(configration.GetValue<string>("MongoSettings:ConnectionString"));
            var database = client.GetDatabase(configration.GetValue<string>("MongoSettings:DatabaseName"));

            products = database.GetCollection<Product>(configration.GetValue<string>("MongoSettings:ProductConnectionName"));

            categories = database.GetCollection<Category>(configration.GetValue<string>("MongoSettings:CategoryConnectionName"));

            CatalogContextSeed.SeedData(products,categories);
        }

        public IMongoCollection<Product> products { get; }
        public IMongoCollection<Category> categories { get; }
        
    }
}

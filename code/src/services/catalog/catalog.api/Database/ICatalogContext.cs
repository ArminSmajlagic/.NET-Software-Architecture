using catalog.api.Models;
using MongoDB.Driver;

namespace catalog.api.Database
{
    public interface ICatalogContext
    {
        IMongoCollection<Category> categories { get; }
        IMongoCollection<Product> products { get; }
    }
}
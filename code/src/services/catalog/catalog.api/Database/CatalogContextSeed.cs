using catalog.api.Models;
using MongoDB.Driver;

namespace catalog.api.Database
{
    public static class CatalogContextSeed
    {
        public static async void SeedData(IMongoCollection<Product> products, IMongoCollection<Category> categories)
        {
            if (!categories.Find(x => true).Any())
            {
                await categories.InsertManyAsync(GetCategories());
            }

            if (!products.Find(x => true).Any())
            {
                await products.InsertManyAsync(GetProducts(categories));
            }
        }

        private static IEnumerable<Product> GetProducts(IMongoCollection<Category> categories)
        {
            return new List<Product>() {
                new Product(){
                    id = new Guid().ToString(),
                    name = "product 1",
                    description = "none",
                    price = 100,
                    image = "no image",
                    category_id = categories.Find(x=>x.name == "products 1").FirstOrDefault().id.ToString()
                },
                new Product(){
                    id = new Guid().ToString(),
                    name = "product 2",
                    description = "none",
                    price = 101,
                    image = "no image",
                    category_id = categories.Find(x=>x.name == "products 2").FirstOrDefault().id.ToString()
                },
                new Product(){
                    id = new Guid().ToString(),
                    name = "product 3",
                    description = "none",
                    price = 102,
                    image = "no image",
                    category_id = categories.Find(x=>x.name == "products 3").FirstOrDefault().id.ToString()
                },
            };
        }

        private static IEnumerable<Category> GetCategories()
        {
            return new List<Category>() {
                new Category()
                {
                    id = new Guid().ToString(),
                    name = "products 1",
                    decription = "none"
                },
                new Category()
                {
                    id = new Guid().ToString(),
                    name = "products 2",
                    decription = "none"
                },
                new Category()
                {
                    id = new Guid().ToString(),
                    name = "products 3",
                    decription = "none"
                },
            };
        }
    }
}

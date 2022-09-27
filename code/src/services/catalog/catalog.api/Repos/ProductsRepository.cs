using catalog.api.Database;
using catalog.api.IRepos;
using catalog.api.Models;
using catalog.api.Models.SearchObject;
using MongoDB.Driver;

namespace catalog.api.Repos
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ICatalogContext context;

        public ProductsRepository(ICatalogContext context)
        {
            this.context = context;
        }

        public async Task<Product> GetProduct(ProductSearchObject search)
        {
            if (!string.IsNullOrEmpty(search.id))
            {
                var result = await context.products.Find(x => x.id == search.id).FirstOrDefaultAsync();
                return result;
            }
            else if (!string.IsNullOrEmpty(search.category_id))
            {
                var result = await context.products.Find(x => x.category_id == search.category_id).FirstOrDefaultAsync();
                return result;
            }
            else if (!string.IsNullOrEmpty(search.name))
            {
                var result = await context.products.Find(x => x.name.ToLower().StartsWith(search.name.ToLower())).FirstOrDefaultAsync();
                return result;
            }

            return null;
        }



        public async Task<IEnumerable<Product>> GetProducts(ProductSearchObject search)
        {
            if (!string.IsNullOrEmpty(search.name))
            {
                var result = await context.products.Find(x => x.name.ToLower().StartsWith(search.name.ToLower())).ToListAsync();

                return result;
            }
            else
            {
                var result = await context.products.Find(x => true).ToListAsync();

                return result;
            }

        }

        public async Task<Product> Insert(Product product)
        {
           await context.products.InsertOneAsync(product);

            return product;
        }

        public async Task<Product> Delete(string id)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(x=>x.id,id);

            var deleteResult = await context.products.DeleteOneAsync(filter);

            return null;
        }

        public async Task<Product> Update(Product product)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(x => x.id, product.id);

            var updateResult = await context.products.ReplaceOneAsync(filter,product);

            if (updateResult.ModifiedCount>0)
                return product;
            else
                return null;
        }
    }
}

using catalog.api.Models;
using catalog.api.Models.SearchObject;

namespace catalog.api.IRepos
{
    public interface IProductsRepository
    {
        Task<Product> GetProduct(ProductSearchObject search);
        Task<IEnumerable<Product>> GetProducts(ProductSearchObject search);
        Task<Product> Delete(string product);
        Task<Product> Insert(Product product);
        Task<Product> Update(Product product);
    }
}
using catalog.api.Models;

namespace catalog.api.IRepos
{
    public interface ICategoriesRepository
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategory(string id);
    }
}
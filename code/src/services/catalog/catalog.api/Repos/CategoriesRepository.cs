using catalog.api.Database;
using catalog.api.IRepos;
using catalog.api.Models;
using MongoDB.Driver;

namespace catalog.api.Repos
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly ICatalogContext context;

        public CategoriesRepository(ICatalogContext context)
        {
            this.context = context;
        }

        public async Task<Category> GetCategory(string id)
        {
            var result = await context.categories.Find(x => x.id == id).FirstOrDefaultAsync();


            return result;
        }



        public async Task<IEnumerable<Category>> GetCategories()
        {
            var result = await context.categories.Find(x => true).ToListAsync();

            return result;
        }
    }
}

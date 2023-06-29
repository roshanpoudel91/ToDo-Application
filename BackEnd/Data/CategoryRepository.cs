using Domain;
using System;

namespace Data
{
   
    public class CategoryRepository : Repository<Category> , ICategoryRepository
    {
        private readonly ApiDataContext databaseContext;

        public CategoryRepository(ApiDataContext databaseContext) : base(databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public List<Category> GetCategories()
        {
            var categories = databaseContext.Categories
                .ToList();

            return categories;

        }

    }
}

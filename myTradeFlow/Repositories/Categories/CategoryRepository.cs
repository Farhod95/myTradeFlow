using myTradeFlow.Data;
using myTradeFlow.Models.Categories;

namespace myTradeFlow.Repositories.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext applicationDbContext;
        public CategoryRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async ValueTask<Category> InsertCategoryAsync(Category category)
        {
            await this.applicationDbContext.Categories.AddAsync(category);
            await this.applicationDbContext.SaveChangesAsync();

            return category;
        }

        public IQueryable<Category> SelectAllCategoriesAsync()=> 
            this.applicationDbContext.Categories;

        public async ValueTask<Category> SelectCategoryByIdAsync(Guid categoryId) =>
            await this.applicationDbContext.Categories.FindAsync(categoryId);
    }
}
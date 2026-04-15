using myTradeFlow.Models.Categories;

namespace myTradeFlow.Services.Categories
{
    public interface ICategoryService
    {
        ValueTask<Category> AddCategoryAsync(Category category);
        IQueryable<Category> RetrieveAllCategories();
        ValueTask<Category> RetrieveCategoryByIdAsync(Guid categoryId);
        ValueTask<Category> ModifyCategoryAsync(Category category);
        ValueTask<Category> RemoveCategoryAsync(Guid categoryId);
    }
}
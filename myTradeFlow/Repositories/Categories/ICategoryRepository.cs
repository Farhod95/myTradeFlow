using myTradeFlow.Models.Categories;

namespace myTradeFlow.Repositories.Categories
{
    public interface ICategoryRepository
    {
        ValueTask<Category> InsertCategoryAsync(Category category);
        IQueryable<Category> SelectAllCategoriesAsync();
        ValueTask<Category> SelectCategoryByIdAsync(Guid categoryId);
        ValueTask<Category> UpdateCategoryAsync(Category category);
        ValueTask<Category> DeleteCategoryAsync(Category category);
    }
}

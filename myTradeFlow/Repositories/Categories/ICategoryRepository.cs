using myTradeFlow.Models.Categories;

namespace myTradeFlow.Repositories.Categories
{
    public interface ICategoryRepository
    {
        ValueTask<Category> InsertCategoryAsync(Category category);
    }
}

using myTradeFlow.Models.Categories;

namespace myTradeFlow.Services.Categories
{
    public interface ICategoryService
    {
        ValueTask<Category> AddCategoryAsync(Category category);
    }
}
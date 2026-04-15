using myTradeFlow.Data;
using myTradeFlow.Models.Categories;
using myTradeFlow.Models.Exceptions;

namespace myTradeFlow.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryService categoryService;
        public CategoryService(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public async ValueTask<Category> AddCategoryAsync(Category category)
        {
            if(category == null)
            {
                throw new ValidationException("Category bo'sh bo'lishi mumkin emas!");
            }

            if (string.IsNullOrWhiteSpace(category.Name))
            {
                throw new ValidationException("Category nomi bo'sh bo'lishi mumkin emas!");
            }

            return await categoryService.AddCategoryAsync(category);
        }
    }
}
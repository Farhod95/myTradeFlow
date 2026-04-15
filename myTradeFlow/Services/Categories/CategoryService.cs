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

        public IQueryable<Category> RetrieveAllCategories()=>
            this.categoryService.RetrieveAllCategories();

        public async ValueTask<Category> RetrieveCategoryByIdAsync(Guid categoryId)
        {
            if(categoryId == Guid.Empty)
            {
                throw new ValidationException("Category Id bo'sh bo'lishi mumkin emas !");
            }

            var myCategory = await categoryService.RetrieveCategoryByIdAsync(categoryId);
            if (myCategory == null)
            {
                throw new NotFoundException($"Categorys jadvalida {categoryId} Idli category topilmadi!");
            }

            return myCategory;
        }
    }
}
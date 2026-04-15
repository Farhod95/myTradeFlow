using myTradeFlow.Data;
using myTradeFlow.Models.Categories;
using myTradeFlow.Models.Exceptions;
using myTradeFlow.Repositories.Categories;

namespace myTradeFlow.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
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

            return await this.categoryRepository.InsertCategoryAsync(category);
        }

        public IQueryable<Category> RetrieveAllCategories()=>
            this.categoryRepository.SelectAllCategoriesAsync();

        public async ValueTask<Category> RetrieveCategoryByIdAsync(Guid categoryId)
        {
            if(categoryId == Guid.Empty)
            {
                throw new ValidationException("Category Id bo'sh bo'lishi mumkin emas !");
            }

            var myCategory = await this.categoryRepository.SelectCategoryByIdAsync(categoryId);
            if (myCategory == null)
            {
                throw new NotFoundException($"Categorys jadvalida {categoryId} Idli category topilmadi!");
            }

            return myCategory;
        }

        public async ValueTask<Category> ModifyCategoryAsync(Category category)
        {
            if(category == null)
            {
                throw new ValidationException("Category bo'sh bo'lishi mumkin emas!");
            }

            if (string.IsNullOrWhiteSpace(category.Name))
            {
                throw new ValidationException("Category nomi bo'sh bo'lishi mumkin emas!");
            }

            var myCategory = await this.categoryRepository.UpdateCategoryAsync(category);

            if (myCategory == null)
            {
                throw new NotFoundException($"Categorys jadvalida bu {category.Id} Idli category topilmadi!");
            }

            return myCategory;
        }

        public async ValueTask<Category> RemoveCategoryAsync(Guid categoryId)
        {
            if(categoryId == Guid.Empty)
            {
                throw new ValidationException("Category Id bo'sh bo'lishi mumkin emas !");
            }

            var myCategory = await this.categoryRepository.DeleteCategoryAsync(categoryId);

            if(myCategory == null)
            {
                throw new NotFoundException("Categorys jadvalida bu {categoryId} Idli category topilmadi!");
            }

            return myCategory;
        }
    }
}
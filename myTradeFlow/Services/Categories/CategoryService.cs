using myTradeFlow.Data;

namespace myTradeFlow.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext applicationDbContext;
        public CategoryService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
    }
}
using myTradeFlow.Data;

namespace myTradeFlow.Repositories.Categories
{
    public class CategoryRepository
    {
        private readonly ApplicationDbContext applicationDbContext;
        public CategoryRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
    }
}
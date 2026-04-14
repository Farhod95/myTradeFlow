using myTradeFlow.Data;

namespace myTradeFlow.Repositories.Brands
{
    public class BrandRepository
    {
        private readonly ApplicationDbContext applicationDbContext;
        public BrandRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
    }
}
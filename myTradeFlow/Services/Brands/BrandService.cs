using myTradeFlow.Data;

namespace myTradeFlow.Services.Brands
{
    public class BrandService : IBrandService
    {
        private readonly ApplicationDbContext applicationDbContext;
        public BrandService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
    }
}
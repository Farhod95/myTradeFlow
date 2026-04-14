using myTradeFlow.Data;
using myTradeFlow.Models.Brands;

namespace myTradeFlow.Repositories.Brands
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ApplicationDbContext applicationDbContext;
        public BrandRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async ValueTask<Brand> InsertBrandAsync(Brand brand)
        {
            await this.applicationDbContext.Brands.AddAsync(brand);
            await this.applicationDbContext.SaveChangesAsync();

            return brand;
        }
    }
}
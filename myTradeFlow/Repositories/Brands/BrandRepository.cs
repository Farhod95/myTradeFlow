using Microsoft.EntityFrameworkCore;
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
            this.applicationDbContext.Entry(brand).State = EntityState.Added;
            await this.applicationDbContext.SaveChangesAsync();

            return brand;
        }

        public IQueryable<Brand> SelectAllBrands() =>
            this.applicationDbContext.Brands;

        public async ValueTask<Brand> SelectBrandByIdAsync(Guid brandId) =>
            await applicationDbContext.Brands.FindAsync(brandId);

        public async ValueTask<Brand> UpdateBrandAsync(Brand brand)
        {
            this.applicationDbContext.Entry(brand).State = EntityState.Modified;
            await this.applicationDbContext.SaveChangesAsync();

            return brand;
        }

        public async ValueTask<Brand> DeleteBrandAsync(Brand brand)
        {
            this.applicationDbContext.Entry(brand).State = EntityState.Deleted;
            await this.applicationDbContext.SaveChangesAsync();

            return brand;
        }
    }
}
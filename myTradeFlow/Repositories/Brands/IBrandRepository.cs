using myTradeFlow.Models.Brands;

namespace myTradeFlow.Repositories.Brands
{
    public interface IBrandRepository
    {
        ValueTask<Brand> InsertBrandAsync(Brand brand);
        IQueryable<Brand> SelectAllBrands();
        ValueTask<Brand> SelectBrandByIdAsync(Guid brandId);
        ValueTask<Brand> UpdateBrandAsync(Brand brand);
    }
}
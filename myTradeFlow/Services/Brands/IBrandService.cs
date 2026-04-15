using myTradeFlow.Models.Brands;

namespace myTradeFlow.Services.Brands
{
    public interface IBrandService
    {
        ValueTask<Brand> AddBrandAsync(Brand brand);
        IQueryable<Brand> RetrieveAllBrands();
    }
}
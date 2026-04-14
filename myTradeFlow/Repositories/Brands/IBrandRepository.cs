using myTradeFlow.Models.Brands;

namespace myTradeFlow.Repositories.Brands
{
    public interface IBrandRepository
    {
        ValueTask<Brand> InsertBrandAsync(Brand brand);
    }
}
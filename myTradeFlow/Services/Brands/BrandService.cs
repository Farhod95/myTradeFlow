using myTradeFlow.Data;
using myTradeFlow.Models.Brands;
using myTradeFlow.Models.Exceptions;
using myTradeFlow.Repositories.Brands;

namespace myTradeFlow.Services.Brands
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository brandRepository;
        public BrandService(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        public async ValueTask<Brand> AddBrandAsync(Brand brand)
        {
            if(brand == null)
            {
                throw new ValidationException("Brand bo'sh bo'lishi mumkin emas");
            }

            if(string.IsNullOrWhiteSpace(brand.Name))
            {
                throw new ValidationException("Brand nomi bo'sh bo'lishi mumkin emas");
            }

            return await this.brandRepository.InsertBrandAsync(brand);
        }
    }
}
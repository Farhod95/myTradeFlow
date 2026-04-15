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

        public IQueryable<Brand> RetrieveAllBrands()=>
            this.brandRepository.SelectAllBrands();

        public async ValueTask<Brand> RetrieveBrandByIdAsync(Guid brandId)
        {
            if(brandId == Guid.Empty)
            {
                throw new ValidationException("Brand Id bo'sh bo'lishi mumkin emas");
            }

            var myBrand =  await this.brandRepository.SelectBrandByIdAsync(brandId);

            if(myBrand == null)
            {
                throw new ValidationException($"Brands jadvalida {brandId} Idli topilmadi !");
            }

            return myBrand;
        }

        public ValueTask<Brand> ModifyBrandAsync(Brand brand)
        {
            if(brand == null)
            {
                throw new ValidationException("Brand bo'sh bo'lishi mumkin emas");
            }
            if(string.IsNullOrWhiteSpace(brand.Name))
            {
                throw new ValidationException("Brand nomi bo'sh bo'lishi mumkin emas");
            }

            var myBrand = this.brandRepository.UpdateBrandAsync(brand);

            if(myBrand == null)
            {
                throw new ValidationException($"Brands jadvalida {brand.Id} Idli topilmadi !");
            }

            return myBrand;
        }

        public ValueTask<Brand> RemoveBrandAsync(Guid brandId)
        {
            if(brandId == Guid.Empty)
            {
                throw new ValidationException("Brand Id bo'sh bo'lishi mumkin emas");
            }

            var myBrand = this.brandRepository.DeleteBrandAsync(brandId);

            if(myBrand == null)
            {
                throw new NotFoundException($"Brands jadvalida {brandId} Idli topilmadi !");
            }

            return myBrand;
        }
    }
}
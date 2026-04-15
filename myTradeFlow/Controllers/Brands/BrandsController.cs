using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myTradeFlow.Models.Brands;
using myTradeFlow.Models.Exceptions;
using myTradeFlow.Services.Brands;

namespace myTradeFlow.Controllers.Brands
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService brandService;
        public BrandsController(IBrandService brandService)
        {
            this.brandService = brandService;
        }

        [HttpPost]
        public async ValueTask<ActionResult<Brand>> PostBrandAsync(Brand brand)
        {
            try
            {
                var myBrand = await this.brandService.AddBrandAsync(brand);

                return StatusCode(201, myBrand);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ichki server xatosi yuz berdi.");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> GetAllBrandsAsync()
        {
            try
            {
                var brandsQuery = this.brandService.RetrieveAllBrands();
                var brands = await brandsQuery.ToListAsync();
                return StatusCode(200, brands);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ichki server xatosi yuz berdi.");
            }
        }

        [HttpGet("{brandId}")]
        public async ValueTask<ActionResult<Brand>> GetBrandByIdAsync(Guid brandId)
        {
            try
            {
                var brand = await this.brandService.RetrieveBrandByIdAsync(brandId);

                return Ok(brand);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ichki server xatosi yuz berdi.");
            }
        }

        [HttpPut]
        public async ValueTask<ActionResult<Brand>> PutBrandAsync(Brand brand)
        {
            try
            {
                var myBrand = await this.brandService.ModifyBrandAsync(brand);

                return Ok(myBrand);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ichki server xatosi yuz berdi.");
            }
        }

        [HttpDelete]
        public async ValueTask<ActionResult<Brand>> DeleteBrandAsync(Guid brandId)
        {
            try
            {
                var myBrand = await this.brandService.RemoveBrandAsync(brandId);

                return Ok(myBrand);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ichki server xatosi yuz berdi.");
            }
        }
    }
}

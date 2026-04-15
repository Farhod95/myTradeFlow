using Microsoft.AspNetCore.Mvc;
using myTradeFlow.Models.Brands;
using myTradeFlow.Services.Brands;
using System.ComponentModel.DataAnnotations;

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
            catch(ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ichki server xatosi yuz berdi.");
            }
        }
    }
}

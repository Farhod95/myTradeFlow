using Microsoft.AspNetCore.Mvc;
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
    }
}

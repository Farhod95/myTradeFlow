using Microsoft.AspNetCore.Mvc;
using myTradeFlow.Services.Categories;

namespace myTradeFlow.Controllers.Categories
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
    }
}
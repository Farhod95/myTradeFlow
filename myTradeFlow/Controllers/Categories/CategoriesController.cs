using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myTradeFlow.Models.Categories;
using myTradeFlow.Services.Categories;
using System.ComponentModel.DataAnnotations;

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

        [HttpPost]
        public async ValueTask<ActionResult> PostCategoryAsync(Category category)
        {
            try
            {
                var myCategory = await categoryService.AddCategoryAsync(category);

                return StatusCode(201, myCategory);
            }
            catch(ValidationException  ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ichki server xatosi yuz berdi.");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategoriesAsync()
        {
            try
            {
                var categoriesQuery = this.categoryService.RetrieveAllCategories();

                var categories = await categoriesQuery.ToListAsync();

                return StatusCode(201, categories);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ichki server xatosi yuz berdi.");
            }
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CookingMasterAPI.Data;
using CookingMasterAPI.Models.Entity;
using CookingMasterAPI.Services.ServiceInterfaces;
using CookingMasterAPI.Enums.IngCategoryStatusEnums;

namespace CookingMasterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientCategoryController : ControllerBase
    {
        private readonly IIngredientCategoryService _service;
        public IngredientCategoryController(IIngredientCategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngredientCategory>>> GetIngredientCategoriesAsync()
        {
            try
            {
                var result = await _service.GetIngredientCategoriesAsync();

                if (result.Status is GetIngredientCategoriesEnum.Success)
                {
                    return Ok(result.IngredientCategories);
                }

                return NotFound(result.Description);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //TODO: Fix this method
        [HttpGet("{categoryId}")]
        public async Task<ActionResult<IngredientCategory>> GetIngredientCategory(int categoryId)
        {
            try
            {
                if (_context.IngredientCategories is null)
                {
                    return NotFound();
                }
                var ingredientCategory = await _context.IngredientCategories.FindAsync(categoryId);
                //var ingredientCategory = await _context.IngredientCategories.SingleOrDefaultAsync(c => c.CategoryId == categoryId);

                if (ingredientCategory is null)
                {
                    return NotFound();
                }
                return ingredientCategory;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

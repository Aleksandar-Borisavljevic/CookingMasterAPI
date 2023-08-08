using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("all")]
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

        [HttpGet("{categoryId}")]
        public async Task<ActionResult<IngredientCategory>> GetIngredientCategoryAsync(int categoryId)
        {
            try
            {
                var result = await _service.GetIngredientCategoryAsync(categoryId);
                if (result.Status is GetIngredientCategoryEnum.Success)
                {
                    return Ok(result.IngredientCategory);
                }
                return NotFound(result.Description);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

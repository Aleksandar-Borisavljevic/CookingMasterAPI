using Microsoft.AspNetCore.Mvc;
using CookingMasterAPI.Models.Entity;
using CookingMasterAPI.Services.ServiceInterfaces;
using CookingMasterAPI.Enums.IngCategoryStatusEnums.QueryEnums;
using CookingMasterAPI.Models.Request.IngredientCategoryRequests;
using CookingMasterAPI.Enums.IngCategoryStatusEnums.CommandEnums;
using Microsoft.AspNetCore.JsonPatch;

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

        [HttpGet("{uid}")]
        public async Task<ActionResult<IngredientCategory>> GetIngredientCategoryAsync(string uid)
        {
            try
            {
                var result = await _service.GetIngredientCategoryAsync(uid);
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

        [HttpPost("createCategory")]
        public async Task<IActionResult> CreateIngredientCategoryAsync(CreateIngredientCategoryRequest request)
        {
            try
            {
                var result = await _service.CreateIngredientCategoryAsync(request);
                if (result.Status is CreateIngredientCategoryEnum.Success)
                {
                    return Ok(result.Description);
                }
                return BadRequest(result.Description);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("{uid}")]
        public async Task<IActionResult> DeleteIngredientCategoryAsync(string uid)
        {
            try
            {
                var result = await _service.DeleteIngredientCategoryAsync(uid);
                if (result.Status is DeleteIngredientCategoryEnum.Success)
                {
                    return Ok(result.Description);
                }
                return BadRequest(result.Description);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //[HttpPatch("{categoryId}")]
        //public IActionResult PatchProduct(int id, [FromBody] JsonPatchDocument<CreateIngredientCategoryRequest> request)
        //{


        //    var product = _products.FirstOrDefault(p => p.Id == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    patchDocument.ApplyTo(product, ModelState);

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    return NoContent();
        //}
    }
}

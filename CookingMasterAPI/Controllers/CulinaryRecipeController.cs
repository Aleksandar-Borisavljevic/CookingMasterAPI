using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using CookingMasterAPI.Models.Entity;
using CookingMasterAPI.Services.ServiceInterfaces;
using CookingMasterAPI.Enums.IngredientStatusEnums.QueryEnums;
using CookingMasterAPI.Models.Request.IngredientRequests;
using CookingMasterAPI.Enums.IngredientStatusEnums.CommandEnums;
using CookingMasterAPI.Data;
using CookingMasterAPI.Enums.CulinaryRecipeStatusEnums.QueryEnums;
using CookingMasterAPI.Models.Request.CulinaryRecipeRequests;
using CookingMasterAPI.Enums.CulinaryRecipeStatusEnums.CommandEnums;

namespace CookingMasterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CulinaryRecipeController : ControllerBase
    {
        private readonly ICulinaryRecipeService _service;
        public CulinaryRecipeController(ICulinaryRecipeService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<CulinaryRecipe>>> GetCulinaryRecipesAsync()
        {
            try
            {
                var result = await _service.GetCulinaryRecipesAsync();

                if (result.Status is GetCulinaryRecipesEnum.Success)
                {
                    return Ok(result.CulinaryRecipes);
                }

                return NotFound(result.Description);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{uid}")]
        public async Task<ActionResult<CulinaryRecipe>> GetCulinaryRecipe(string uid)
        {
            try
            {
                var result = await _service.GetCulinaryRecipeAsync(uid);
                if (result.Status is GetCulinaryRecipeEnum.Success)
                {
                    return Ok(result.CulinaryRecipe);
                }
                return NotFound(result.Description);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("createCulinaryRecipe")]
        public async Task<IActionResult> CreateCulinaryRecipeAsync(CreateCulinaryRecipeRequest request)
        {
            try
            {
                var result = await _service.CreateCulinaryRecipeAsync(request);
                if (result.Status is CreateCulinaryRecipeEnum.Success)
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
        public async Task<IActionResult> DeleteCulinaryRecipeAsync(string uid)
        {
            try
            {
                var result = await _service.DeleteCulinaryRecipeAsync(uid);
                if (result.Status is DeleteCulinaryRecipeEnum.Success)
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

        [HttpPatch("{uid}")]
        public async Task<IActionResult> PatchCulinaryRecipeAsync(string uid, [FromBody] JsonPatchDocument<CulinaryRecipe> request)
        {
            try
            {
                var result = await _service.UpdateCulinaryRecipeAsync(uid, request);
                if (result.Status is UpdateCulinaryRecipeEnum.Success)
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
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using CookingMasterAPI.Models.Entity;
using CookingMasterAPI.Services.ServiceInterfaces;
using CookingMasterAPI.Enums.IngredientStatusEnums.QueryEnums;
using CookingMasterAPI.Models.Request.IngredientRequests;
using CookingMasterAPI.Enums.IngredientStatusEnums.CommandEnums;
using CookingMasterAPI.Data;
using CookingMasterAPI.Enums.CulinaryRecipeStatusEnums.QueryEnums;

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

        //[HttpPost("createCulinaryRecipe")]
        //public async Task<IActionResult> CreateCulinaryRecipeAsync(CreateCulinaryRecipeRequest request)
        //{
        //    try
        //    {
        //        var result = await _service.CreateCulinaryRecipeAsync(request);
        //        if (result.Status is CreateCulinaryRecipeEnum.Success)
        //        {
        //            return Ok(result.Description);
        //        }
        //        return BadRequest(result.Description);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //[HttpDelete("{uid}")]
        //public async Task<IActionResult> DeleteIngredientAsync(string uid)
        //{
        //    try
        //    {
        //        var result = await _service.DeleteIngredientAsync(uid);
        //        if (result.Status is DeleteIngredientEnum.Success)
        //        {
        //            return Ok(result.Description);
        //        }
        //        return BadRequest(result.Description);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //[HttpPatch("{uid}")]
        //public async Task<IActionResult> PatchIngredientAsync(string uid, [FromBody] JsonPatchDocument<Ingredient> request)
        //{
        //    try
        //    {
        //        var result = await _service.UpdateIngredientAsync(uid, request);
        //        if (result.Status is UpdateIngredientEnum.Success)
        //        {
        //            return Ok(result.Description);
        //        }
        //        return BadRequest(result.Description);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        ////string userUid, string ingredientUid
        //[HttpPost("createUserIngredient")]
        //public async Task<IActionResult> CreateUserIngredientAsync(Tuple<string, string> Uids)
        //{
        //    try
        //    {
        //        var result = await _service.CreateUserIngredientAsync(Uids.Item1, Uids.Item2);
        //        if (result.Status is CreateUserIngredientEnum.Success)
        //        {
        //            return Ok(result.Description);
        //        }
        //        return BadRequest(result.Description);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //[HttpDelete("deleteUserIngredient")]
        //public async Task<IActionResult> DeleteUserIngredientAsync(Tuple<int, int> Ids)
        //{
        //    try
        //    {
        //        var result = await _service.DeleteUserIngredientAsync(Ids.Item1, Ids.Item2);
        //        if (result.Status is DeleteUserIngredientEnum.Success)
        //        {
        //            return Ok(result.Description);
        //        }
        //        return BadRequest(result.Description);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}

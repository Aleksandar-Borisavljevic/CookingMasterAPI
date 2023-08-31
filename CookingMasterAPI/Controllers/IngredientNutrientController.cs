using Microsoft.AspNetCore.Mvc;
using CookingMasterAPI.Enums.IngNutrientStatusEnums.CommandEnums;
using CookingMasterAPI.Models.Request.IngredientNutrientRequests;
using CookingMasterAPI.Services.ServiceInterfaces;
using CookingMasterAPI.Enums.IngredientStatusEnums.QueryEnums;
using CookingMasterAPI.Models.Entity;
using CookingMasterAPI.Enums.IngNutrientStatusEnums.QueryEnums;
using CookingMasterAPI.Enums.IngredientStatusEnums.CommandEnums;
using Azure;
using Microsoft.AspNetCore.JsonPatch;

namespace CookingMasterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class IngredientNutrientController : ControllerBase
    {
        private readonly IIngredientNutrientService _service;

        public IngredientNutrientController(IIngredientNutrientService service)
        {
            _service = service;
        }

        [HttpPost("createIngredientNutrient")]
        public async Task<IActionResult> CreateIngredientNutrientsAsync(CreateIngredientNutrientRequest request)
        {
            try
            {
                var result = await _service.CreateIngredientNutrientsAsync(request);
                if (result.Status is CreateIngredientNutrientEnum.Success)
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

        [HttpGet("{uid}")]
        public async Task<ActionResult<IngredientNutrient>> GetIngredientNutrientsAsync(string uid)
        {
            try
            {
                var result = await _service.GetIngredientNutrientsAsync(uid);
                if (result.Status is GetIngredientNutrientEnum.Success)
                {
                    return Ok(result.IngredientNutrient);
                }
                return NotFound(result.Description);
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpDelete("{uid}")]
        public async Task<IActionResult> DeleteIngredientNutrientsAsync(string uid)
        {
            try
            {
                var result = await _service.DeleteIngredientNutrientsAsync(uid);
                if (result.Status is DeleteIngredientNutrientEnum.Success)
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
        public async Task<IActionResult> PatchIngredientNutrientsAsync(string uid, [FromBody] JsonPatchDocument<IngredientNutrient> request)
        {
            try
            {
                var result = await _service.UpdateIngredientNutrientsAsync(uid, request);
                if (result.Status is UpdateIngredientNutrientEnum.Success)
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

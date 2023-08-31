using Microsoft.AspNetCore.Mvc;
using CookingMasterAPI.Enums.IngNutrientStatusEnums.CommandEnums;
using CookingMasterAPI.Models.Request.IngredientNutrientRequests;
using CookingMasterAPI.Services.ServiceInterfaces;
using CookingMasterAPI.Enums.IngredientStatusEnums.QueryEnums;
using CookingMasterAPI.Models.Entity;
using CookingMasterAPI.Enums.IngNutrientStatusEnums.QueryEnums;

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
        public async Task<IActionResult> CreateIngredientNutrientAsync(CreateIngredientNutrientRequest request)
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
        public async Task<ActionResult<IngredientNutrient>> GetIngredientNutrientAsync(string uid)
        {
            try
            {
                var result = await _service.GetIngredientNutrientAsync(uid);
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
    }
}

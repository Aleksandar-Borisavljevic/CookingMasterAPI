using CookingMasterAPI.Enums.IngNutrientStatusEnums.CommandEnums;
using CookingMasterAPI.Enums.IngredientStatusEnums.CommandEnums;
using CookingMasterAPI.Models.Request.IngredientRequests;
using CookingMasterAPI.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

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
    }
}

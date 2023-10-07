using Microsoft.AspNetCore.Mvc;
using CookingMasterAPI.Services.ServiceInterfaces;
using CookingMasterAPI.Models.Response;
using CookingMasterAPI.Enums.CuisineTypeEnums.QueryEnums;

namespace CookingMasterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuisineTypeController : ControllerBase
    {
        private readonly ICuisineTypeService _service;
        public CuisineTypeController(ICuisineTypeService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<CuisineTypeResponse>>> GetCuisineTypesAsync()
        {
            try
            {
                var result = await _service.GetCuisineTypesAsync();

                if (result.Status is GetCuisineTypesEnum.Success)
                {
                    return Ok(result.CuisineTypes);
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

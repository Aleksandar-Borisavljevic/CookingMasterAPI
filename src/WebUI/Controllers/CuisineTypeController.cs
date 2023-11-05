using CookingMasterApi.Application.CuisineTypes.Queries.GetCuisineTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CookingMasterApi.WebUI.Controllers;

[Authorize]
public class CuisineTypeController : ApiControllerBase
{
    [HttpGet(nameof(GetCuisineTypes))]
    public async Task<ActionResult<IQueryable<CuisineTypeDto>>> GetCuisineTypes()
    {
        return Ok(await Mediator.Send(new GetCuisineTypesQuery()));
    }

}

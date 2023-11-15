using CookingMasterApi.Application.CuisineTypes.Queries.GetCuisineTypes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace CookingMasterApi.WebUI.Controllers;

public class CuisineTypeController : ApiControllerBase
{
    [HttpGet(nameof(GetCuisineTypes))]
    [EnableQuery]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<ActionResult<IQueryable<CuisineTypeDto>>> GetCuisineTypes()
    {
        return Ok(await Mediator.Send(new GetCuisineTypesQuery()));
    }

}

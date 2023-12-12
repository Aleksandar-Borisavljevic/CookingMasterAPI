using CookingMasterApi.Application.CulinaryRecipes.Commands.Create;
using CookingMasterApi.Application.CulinaryRecipes.Queries;
using CookingMasterApi.Domain.Entities;
using CookingMasterApi.WebUI.Controllers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace WebUI.Controllers;
public class CulinaryRecipeController : ApiControllerBase
{
    [HttpPost(nameof(CreateCulinaryRecipe))]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<ActionResult<CreateCulinaryRecipeCommandResult>> CreateCulinaryRecipe(CreateCulinaryRecipeCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpGet(nameof(GetCulinaryRecipes))]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [EnableQuery]
    public async Task<ActionResult<IQueryable<CulinaryRecipeDto>>> GetCulinaryRecipes()
    {
        return Ok(await Mediator.Send(new GetCulinaryRecipesQuery()));
    }
}

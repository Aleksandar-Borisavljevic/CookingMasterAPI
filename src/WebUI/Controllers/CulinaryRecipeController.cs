using CookingMasterApi.Application.CulinaryRecipes.Commands.Create;
using CookingMasterApi.Application.IngredientCategories.Commands.Create;
using CookingMasterApi.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;
public class CulinaryRecipeController : ApiControllerBase
{
    [HttpPost(nameof(CreateCulinaryRecipe))]
    public async Task<ActionResult<CreateCulinaryRecipeCommandResult>> CreateCulinaryRecipe(CreateCulinaryRecipeCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
}

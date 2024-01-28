using CookingMasterApi.Application.Ingredients.Commands.Create;
using CookingMasterApi.Application.Ingredients.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace CookingMasterApi.WebUI.Controllers;

public class IngredientController : ApiControllerBase
{
    [HttpGet(nameof(GetIngredients))]
    [EnableQuery]
    public async Task<ActionResult<IQueryable<IngredientDto>>> GetIngredients()
    {
        return Ok(await Mediator.Send(new GetIngredientsQuery()));
    }

    [HttpPost(nameof(CreateIngredient))]
    public async Task<ActionResult<CreateIngredientCommandResult>> CreateIngredient(CreateIngredientCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
}

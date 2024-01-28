using CookingMasterApi.Application.RecipeIngredients.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace CookingMasterApi.WebUI.Controllers;

public class RecipeIngredientsController : ApiControllerBase
{
    [HttpGet(nameof(GetRecipeIngredients))]
    [EnableQuery]
    public async Task<ActionResult<IQueryable<RecipeIngredientDto>>> GetRecipeIngredients(Guid uid)
    {
        return Ok(await Mediator.Send(new GetRecipeIngredientsQuery {RecipeUid = uid }));
    }

    //[HttpPost(nameof(CreateIngredient))]
    //public async Task<ActionResult<CreateIngredientCommandResult>> CreateIngredient(CreateIngredientCommand command)
    //{
    //    return Ok(await Mediator.Send(command));
    //}
}

using CookingMasterApi.Application.IngredientCategories.Commands.Create;
using CookingMasterApi.Application.IngredientCategories.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace CookingMasterApi.WebUI.Controllers;

public class IngredientCategoryController : ApiControllerBase
{
    [HttpGet(nameof(GetIngredientCategories))]
    [EnableQuery]
    public async Task<ActionResult<IQueryable<IngredientCategoryDto>>> GetIngredientCategories()
    {
        return Ok(await Mediator.Send(new GetIngredientCategoriesQuery()));
    }

    [HttpPost(nameof(CreateIngredientCategory))]
    public async Task<ActionResult<CreateIngredientCategoryCommandResult>> CreateIngredientCategory(CreateIngredientCategoryCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

}


using MediatR;

namespace CookingMasterApi.Application.IngredientCategories.Commands.Create;
public class CreateIngredientCategoryCommand : IRequest<CreateIngredientCategoryCommandResult>
{
    public string CategoryName { get; set; }
    public string IconPath { get; set; } 
}

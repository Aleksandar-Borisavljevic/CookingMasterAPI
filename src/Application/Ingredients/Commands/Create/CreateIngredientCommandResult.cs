using CookingMasterApi.Domain.Entities;

namespace CookingMasterApi.Application.Ingredients.Commands.Create;
public class CreateIngredientCommandResult
{
    public IngredientCategory IngredientCategory { get; set; }
    public IngredientNutrient IngredientNutrient { get; set; }
    public string IngredientName { get; set; }
    public string IconPath { get; set; }
    public short UnitOfMeasure { get; set; }

    public CreateIngredientCommandResult(string ingredientName, string iconPath)
    {
        IngredientName = ingredientName;
        IconPath = iconPath;
    }
}

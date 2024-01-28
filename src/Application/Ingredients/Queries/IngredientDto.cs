using CookingMasterApi.Application.Common.Mappings;
using CookingMasterApi.Domain.Entities;

namespace CookingMasterApi.Application.Ingredients.Queries;
public class IngredientDto : IMapFrom<Ingredient>
{
    public IngredientCategory IngredientCategory { get; set; }
    public IngredientNutrient IngredientNutrient { get; set; }
    public string IngredientName { get; set; }
    public string IconPath { get; set; }
}

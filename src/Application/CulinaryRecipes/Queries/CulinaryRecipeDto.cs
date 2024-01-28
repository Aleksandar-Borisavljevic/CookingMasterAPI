using CookingMasterApi.Application.Common.Mappings;
using CookingMasterApi.Application.Common.Models;
using CookingMasterApi.Domain.Entities;

namespace CookingMasterApi.Application.CulinaryRecipes.Queries;
public class CulinaryRecipeDto : BaseDto, IMapFrom<CulinaryRecipe>
{
    public string RecipeName { get; set; }
    public string RecipeDescription { get; set; }
    public CuisineType CuisineType { get; set; }
}

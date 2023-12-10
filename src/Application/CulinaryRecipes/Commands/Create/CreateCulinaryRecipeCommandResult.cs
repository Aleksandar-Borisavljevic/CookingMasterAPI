using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookingMasterApi.Domain.Entities;

namespace CookingMasterApi.Application.CulinaryRecipes.Commands.Create;
    public class CreateCulinaryRecipeCommandResult
    {
    public string RecipeName { get; set; }
    public string RecipeDescription { get; set; }
    public CuisineType CuisineType { get; set; }

    public CreateCulinaryRecipeCommandResult(string recipeName, string recipeDescription, CuisineType cuisineType)
    {
        RecipeName = recipeName;
        RecipeDescription = recipeDescription;
        CuisineType = cuisineType;
    }
}

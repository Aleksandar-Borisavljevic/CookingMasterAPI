using CookingMasterAPI.Data;
using CookingMasterAPI.Models.Entity;
using CookingMasterAPI.Models.Response;
using Microsoft.EntityFrameworkCore;

namespace CookingMasterAPI.Services.Mappers
{
    public static class CulinaryRecipeMapper
    {
        public static CulinaryRecipeResponse MapCulinaryRecipeToResponse(CulinaryRecipe culinaryRecipe, APIDbContext context)
        {
            var ingredients = context.Ingredients
                .Where(ingredient => context.RecipeIngredients
                .Any(ri => ri.CulinaryRecipe.CulinaryRecipeId == culinaryRecipe.CulinaryRecipeId && ri.Ingredient.IngredientId == ingredient.IngredientId)).ToList();

            return new CulinaryRecipeResponse
                (
                culinaryRecipe.CuisineType.CuisineName,
                AuthMapper.MapUserToResponse(culinaryRecipe.User, context),
                IngredientMapper.MapIngredientToResponse(ingredients),
                culinaryRecipe.RecipeName,
                culinaryRecipe.RecipeDescription,
                culinaryRecipe.Uid
                );
        }
    }
}

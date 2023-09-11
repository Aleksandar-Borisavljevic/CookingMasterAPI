using CookingMasterAPI.Data;
using CookingMasterAPI.Models.Entity;
using CookingMasterAPI.Models.Response;

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

        public static IEnumerable<CulinaryRecipeResponse> MapCulinaryRecipeToResponse(IEnumerable<CulinaryRecipe> culinaryRecipes, APIDbContext context)
        {
            return culinaryRecipes.Select(item => MapCulinaryRecipeToResponse(item, context));
            //var culinaryRecipeResponse = new List<CulinaryRecipeResponse>();
            //foreach (var item in culinaryRecipes)
            //{
            //    culinaryRecipeResponse.Add(MapCulinaryRecipeToResponse(item, context));
            //}
            //return culinaryRecipeResponse;
        }
    }
}

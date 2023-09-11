using Microsoft.EntityFrameworkCore;
using CookingMasterAPI.Data;
using CookingMasterAPI.Models.Entity;
using CookingMasterAPI.Models.Request.CulinaryRecipeRequests;
using CookingMasterAPI.Models.Response;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using CookingMasterAPI.Helpers;

namespace CookingMasterAPI.Services.Mappers
{
    public static class CulinaryRecipeMapper
    {
        public static async Task<CulinaryRecipe> MapRequestToCulinaryRecipeAsync(CreateCulinaryRecipeRequest request, APIDbContext _context)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Uid == request.UserUid);
            var cuisineType = await _context.CuisineTypes.FirstOrDefaultAsync(ct => ct.Uid == request.CuisineTypeUid);

            if (user is null)
            {
                return null;
            }

            if (cuisineType is null)
            {
                cuisineType = await _context.CuisineTypes.FirstAsync();
            }

            return new CulinaryRecipe
            {
                CuisineType = cuisineType,
                User = user,
                RecipeName = request.RecipeName,
                RecipeDescription = request.RecipeDescription,
                CreateDate = DateTime.Now,
                Uid = request.RecipeName.Length > 30 ? request.RecipeName
                .Substring(0, 29)
                .CreateUniqueSequence()
                : request.RecipeName
                .CreateUniqueSequence(),
            };
        }

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

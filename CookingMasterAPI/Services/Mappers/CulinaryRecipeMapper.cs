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
            var ingredientResponses = from ri in context.RecipeIngredients
                                      join i in context.Ingredients on ri.Ingredient.IngredientId equals i.IngredientId
                                      join cr in context.CulinaryRecipes on ri.CulinaryRecipe.CulinaryRecipeId equals cr.CulinaryRecipeId
                                      where cr.CulinaryRecipeId == culinaryRecipe.CulinaryRecipeId
                                      select new IngredientResponse
                                      (
                                          i.IngredientId,
                                          i.IngredientName,
                                          i.IconPath,
                                          i.UnitOfMeasure,
                                          ri.Amount,
                                          i.CreateDate,
                                          i.DeleteDate,
                                          IngredientNutrientMapper.MapIngredientNutrientToResponse(i.IngredientNutrient),
                                          null,
                                          i.Uid
                                      );

            var result = ingredientResponses.ToList();


            IngredientNutrientResponse totalNutrients = result.Aggregate(
    new IngredientNutrientResponse(0, 0, 0, 0, 0, ""),
    (acc, x) => new IngredientNutrientResponse(
        acc.Calories + x.IngredientNutrient.Calories * (x.Amount / 100),
        acc.Protein + x.IngredientNutrient.Protein * (x.Amount / 100),
        acc.Carbohydrates + x.IngredientNutrient.Carbohydrates * (x.Amount / 100),
        acc.Fat + x.IngredientNutrient.Fat * (x.Amount / 100),
        acc.Sugar + x.IngredientNutrient.Sugar * (x.Amount / 100),
        ""
    )
);

            return new CulinaryRecipeResponse
                (
                culinaryRecipe.CuisineType.CuisineName,
                AuthMapper.MapUserToResponse(culinaryRecipe.User, context),
                ingredientResponses,
                totalNutrients,
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

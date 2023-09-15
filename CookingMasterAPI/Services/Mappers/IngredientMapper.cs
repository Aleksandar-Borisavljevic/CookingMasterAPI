using Microsoft.EntityFrameworkCore;
using CookingMasterAPI.Helpers;
using CookingMasterAPI.Models.Entity;
using CookingMasterAPI.Models.Request.IngredientRequests;
using CookingMasterAPI.Models.Response;
using CookingMasterAPI.Data;

namespace CookingMasterAPI.Services.Mappers
{
    public static class IngredientMapper
    {
        public static async Task<Ingredient> MapRequestToIngredientAsync(CreateIngredientRequest request, APIDbContext _context)
        {
            var ingredientCategory = await _context.IngredientCategories.FirstOrDefaultAsync(ic => ic.Uid == request.IngredientCategoryUid);

            if (ingredientCategory is null)
            {
                ingredientCategory = await _context.IngredientCategories.LastAsync(); //We're taking the last category in case no category is found
            }

            return new Ingredient
            {
                IngredientCategory = ingredientCategory,
                IngredientName = request.IngredientName,
                IconPath = request.IconPath,
                CreateDate = DateTime.Now,
                Uid = request.IngredientName.CreateUniqueSequence()
            };
        }

        public static IngredientResponse MapIngredientToResponse(Ingredient ingredient)
        {
            return new IngredientResponse
                (
                ingredient.IngredientId,
                ingredient.IngredientName,
                ingredient.IconPath,
                ingredient.UnitOfMeasure,
                0,
                ingredient.CreateDate,
                ingredient.DeleteDate,
                IngredientNutrientMapper.MapIngredientNutrientToResponse(ingredient.IngredientNutrient),
                IngredientCategoryMapper.MapIngredientCategoryToResponse(ingredient.IngredientCategory),
                ingredient.Uid
                );
        }

        public static IEnumerable<IngredientResponse> MapIngredientToResponse(IEnumerable<Ingredient> ingredients)
        {
            return ingredients.Select(MapIngredientToResponse);

            #region Two different ways of selecting
            //return ingredients.Select(i => MapIngredientToResponse(i));

            //var ingredientsResponse = new List<IngredientResponse>();
            //foreach (var item in ingredients)
            //{
            //    ingredientsResponse.Add(MapIngredientToResponse(item));
            //}
            //return ingredientsResponse;
            #endregion
        }
    }
}

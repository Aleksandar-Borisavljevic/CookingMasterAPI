using Microsoft.EntityFrameworkCore;
using CookingMasterAPI.Data;
using CookingMasterAPI.Helpers;
using CookingMasterAPI.Models.Entity;
using CookingMasterAPI.Models.Request.IngredientNutrientRequests;
using CookingMasterAPI.Models.Response;

namespace CookingMasterAPI.Services.Mappers
{
    public static class IngredientNutrientMapper
    {
        public static async Task<IngredientNutrient> MapRequestToIngredientNutrientAsync(CreateIngredientNutrientRequest request, APIDbContext context)
        {
            var ingredient = await context.Ingredients.SingleOrDefaultAsync(x => x.Uid == request.IngredientUid);

            if (ingredient is null)
            {
                return null;
            }

            return new IngredientNutrient
            {
                Calories = request.Calories,
                Protein = request.Protein,
                Carbohydrates = request.Carbohydrates,
                Fat = request.Fat,
                Sugar = request.Sugar,
                CreateDate = DateTime.Now,
                Uid = $"Nut-{ingredient.IngredientName.CreateUniqueSequence()}"
            };
        }

        public static IngredientNutrientResponse MapIngredientNutrientToResponse(IngredientNutrient ingredientNutrient)
        {
            return new IngredientNutrientResponse
            (
               ingredientNutrient.Calories,
               ingredientNutrient.Protein,
               ingredientNutrient.Carbohydrates,
               ingredientNutrient.Fat,
               ingredientNutrient.Sugar,
               ingredientNutrient.Uid
            );
        }

    }
}

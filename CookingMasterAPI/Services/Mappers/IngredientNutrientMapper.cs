using CookingMasterAPI.Data;
using CookingMasterAPI.Helpers;
using CookingMasterAPI.Models.Entity;
using CookingMasterAPI.Models.Request.IngredientRequests;
using CookingMasterAPI.Models.Response;
using Microsoft.EntityFrameworkCore;

namespace CookingMasterAPI.Services.Mappers
{
    public class IngredientNutrientMapper
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
                Ingredient = ingredient,
                Calories = request.Calories,
                Protein = request.Protein,
                Carbohydrates = request.Carbohydrates,
                Fat = request.Fat,
                Sugar = request.Sugar,
                CreateDate = DateTime.Now,
                Uid = $"Nut-{ingredient.IngredientName.CreateUniqueSequence()}"
            };
        }

    }
}

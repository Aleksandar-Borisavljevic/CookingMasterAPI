using Azure;
using CookingMasterAPI.Models.Request.IngredientRequests;
using CookingMasterAPI.Models.Result.IngredientNutrientResult.CommandResult;

namespace CookingMasterAPI.Services.ServiceInterfaces
{
    public interface IIngredientNutrientService
    {
        Task<CreateIngredientNutrientResult> CreateIngredientNutrientsAsync(CreateIngredientNutrientRequest request);

        //Task<GetIngredientNutrientsResult> GetIngredientNutrientsAsync(string uid);


        //Task<DeleteIngredientNutrientsResult> DeleteIngredientNutrientsAsync(string uid);

        //Task<UpdateIngredientNutrientsResult> UpdateIngredientNutrientsAsync(string uid, JsonPatchDocument<IngredientNutrients> request);
    }
}

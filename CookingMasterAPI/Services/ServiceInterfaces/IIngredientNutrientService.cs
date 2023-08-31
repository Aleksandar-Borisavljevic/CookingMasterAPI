using Azure;
using CookingMasterAPI.Models.Request.IngredientNutrientRequests;
using CookingMasterAPI.Models.Result.IngredientNutrientResult.CommandResult;
using CookingMasterAPI.Models.Result.IngredientNutrientResult.QueryResult;

namespace CookingMasterAPI.Services.ServiceInterfaces
{
    public interface IIngredientNutrientService
    {
        Task<CreateIngredientNutrientResult> CreateIngredientNutrientsAsync(CreateIngredientNutrientRequest request);

        Task<GetIngredientNutrientResult> GetIngredientNutrientAsync(string uid);


        //Task<DeleteIngredientNutrientsResult> DeleteIngredientNutrientsAsync(string uid);

        //Task<UpdateIngredientNutrientsResult> UpdateIngredientNutrientsAsync(string uid, JsonPatchDocument<IngredientNutrients> request);
    }
}

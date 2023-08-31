using Azure;
using CookingMasterAPI.Models.Entity;
using CookingMasterAPI.Models.Request.IngredientNutrientRequests;
using CookingMasterAPI.Models.Result.IngredientNutrientResult.CommandResult;
using CookingMasterAPI.Models.Result.IngredientNutrientResult.QueryResult;
using Microsoft.AspNetCore.JsonPatch;

namespace CookingMasterAPI.Services.ServiceInterfaces
{
    public interface IIngredientNutrientService
    {
        Task<CreateIngredientNutrientResult> CreateIngredientNutrientsAsync(CreateIngredientNutrientRequest request);

        Task<GetIngredientNutrientResult> GetIngredientNutrientsAsync(string uid);


        Task<DeleteIngredientNutrientResult> DeleteIngredientNutrientsAsync(string uid);

        Task<UpdateIngredientNutrientResult> UpdateIngredientNutrientsAsync(string uid, JsonPatchDocument<IngredientNutrient> request);
    }
}

using Azure;
using CookingMasterAPI.Models.Entity;
using CookingMasterAPI.Models.Request.IngredientNutrientRequests;
using CookingMasterAPI.Models.Result.CulinaryRecipeResult.QueryResult;
using Microsoft.EntityFrameworkCore;

namespace CookingMasterAPI.Services.ServiceInterfaces
{
    public interface ICulinaryRecipeService
    {
        //Task<CreateCulinaryRecipeResult> CreateCulinaryRecipeAsync(CreateCulinaryRecipeRequest request);
        Task<GetCulinaryRecipeResult> GetCulinaryRecipeAsync(string uid);

        //Task<UpdateCulinaryRecipeResult> UpdateCulinaryRecipeAsync(string uid, JsonPatchDocument<CulinaryRecipe> request);
        //Task<DeleteCulinaryRecipeResult> DeleteCulinaryRecipeAsync(string uid);

    }
}

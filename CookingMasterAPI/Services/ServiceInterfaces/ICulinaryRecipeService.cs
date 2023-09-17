using Microsoft.AspNetCore.JsonPatch;
using CookingMasterAPI.Models.Entity;
using CookingMasterAPI.Models.Request.CulinaryRecipeRequests;
using CookingMasterAPI.Models.Result.CulinaryRecipeResult.CommandResult;
using CookingMasterAPI.Models.Result.CulinaryRecipeResult.QueryResult;

namespace CookingMasterAPI.Services.ServiceInterfaces
{
    public interface ICulinaryRecipeService
    {
        Task<CreateCulinaryRecipeResult> CreateCulinaryRecipeAsync(CreateCulinaryRecipeRequest request);
        Task<GetCulinaryRecipeResult> GetCulinaryRecipeAsync(string uid);

        Task<GetCulinaryRecipesResult> GetCulinaryRecipesByUser(string userUid);

        Task<GetCulinaryRecipesResult> GetCulinaryRecipesAsync();

        Task<UpdateCulinaryRecipeResult> UpdateCulinaryRecipeAsync(string uid, JsonPatchDocument<CulinaryRecipe> request);

        Task<DeleteCulinaryRecipeResult> DeleteCulinaryRecipeAsync(string uid);
    }
}

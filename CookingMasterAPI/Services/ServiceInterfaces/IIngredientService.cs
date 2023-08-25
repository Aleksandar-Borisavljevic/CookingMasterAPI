using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using CookingMasterAPI.Models.Entity;
using CookingMasterAPI.Models.Request.IngredientRequests;
using CookingMasterAPI.Models.Result.IngredientResult.CommandResult;
using CookingMasterAPI.Models.Result.IngredientResult.QueryResult;
using CookingMasterAPI.Data;

namespace CookingMasterAPI.Services.ServiceInterfaces
{
    public interface IIngredientService
    {
        Task<GetIngredientsResult> GetIngredientsAsync();
        Task<GetIngredientResult> GetIngredientAsync(string uid);


        Task<CreateIngredientResult> CreateIngredientAsync(CreateIngredientRequest request);
        Task<DeleteIngredientResult> DeleteIngredientAsync(string uid);
        Task<UpdateIngredientResult> UpdateIngredientAsync(string uid, JsonPatchDocument<Ingredient> request);

        Task<CreateUserIngredientResult> CreateUserIngredientAsync(string userUid, string ingredientUid);
    }
}

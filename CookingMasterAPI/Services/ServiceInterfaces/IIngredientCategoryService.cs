using CookingMasterAPI.Models.Entity;
using CookingMasterAPI.Models.Request.IngredientCategoryRequests;
using CookingMasterAPI.Models.Result.IngredientCategoryResult.CommandResult;
using CookingMasterAPI.Models.Result.IngredientCategoryResult.QueryResult;
using Microsoft.AspNetCore.Mvc;

namespace CookingMasterAPI.Services.ServiceInterfaces
{
    public interface IIngredientCategoryService
    {
        Task<GetIngredientCategoriesResult> GetIngredientCategoriesAsync();
        Task<GetIngredientCategoryResult> GetIngredientCategoryAsync(string uid);

        Task<CreateIngredientCategoryResult> CreateIngredientCategoryAsync(CreateIngredientCategoryRequest request);
        Task<DeleteIngredientCategoryResult> DeleteIngredientCategoryAsync(string uid);
    }
}

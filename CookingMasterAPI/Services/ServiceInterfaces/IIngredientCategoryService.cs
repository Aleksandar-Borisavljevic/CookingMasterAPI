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
        Task<GetIngredientCategoryResult> GetIngredientCategoryAsync(int categoryId);

        Task<CreateIngredientCategoryResult> CreateIngredientCategoryAsync(CreateCategoryRequest request);

        Task<DeleteIngredientCategoryResult> DeleteIngredientCategoryAsync(int categoryId);
    }
}

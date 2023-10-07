using CookingMasterAPI.Models.Request.CulinaryRecipeRequests;
using CookingMasterAPI.Models.Result.CuisineTypeResult.QueryResult;
using CookingMasterAPI.Models.Result.CulinaryRecipeResult.CommandResult;
using CookingMasterAPI.Models.Result.CulinaryRecipeResult.QueryResult;

namespace CookingMasterAPI.Services.ServiceInterfaces
{
    public interface ICuisineTypeService
    {
        Task<GetCuisineTypesResult> GetCuisineTypesAsync();
    }
}

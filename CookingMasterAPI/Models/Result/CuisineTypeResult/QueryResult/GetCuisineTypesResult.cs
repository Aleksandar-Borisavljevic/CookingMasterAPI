using CookingMasterAPI.Enums.CuisineTypeEnums.QueryEnums;
using CookingMasterAPI.Enums.CulinaryRecipeStatusEnums.QueryEnums;
using CookingMasterAPI.Models.Response;

namespace CookingMasterAPI.Models.Result.CuisineTypeResult.QueryResult
{
    public class GetCuisineTypesResult : BaseResult<GetCuisineTypesEnum>
    {
        public GetCuisineTypesResult(GetCuisineTypesEnum status, string description, IEnumerable<CuisineTypeResponse> cuisineTypes) 
            : base(status, description)
        {
            CuisineTypes = cuisineTypes;
        }

        public IEnumerable<CuisineTypeResponse> CuisineTypes { get; set; }
    }
}

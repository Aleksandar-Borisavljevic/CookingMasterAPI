using CookingMasterAPI.Enums.CulinaryRecipeStatusEnums.QueryEnums;
using CookingMasterAPI.Models.Response;

namespace CookingMasterAPI.Models.Result.CulinaryRecipeResult.QueryResult
{
    public class GetCulinaryRecipeResult : BaseResult<GetCulinaryRecipeEnum>
    {
        public GetCulinaryRecipeResult
            (
            GetCulinaryRecipeEnum status,
            string description,
            CulinaryRecipeResponse culinaryRecipe
            )
            : base(status, description)
        {
            CulinaryRecipe = culinaryRecipe;
        }

        public CulinaryRecipeResponse? CulinaryRecipe { get; set; }
    }
}

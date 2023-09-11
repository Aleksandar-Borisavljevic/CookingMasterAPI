using CookingMasterAPI.Enums.CulinaryRecipeStatusEnums.QueryEnums;
using CookingMasterAPI.Models.Response;

namespace CookingMasterAPI.Models.Result.CulinaryRecipeResult.QueryResult
{
    public class GetCulinaryRecipesResult : BaseResult<GetCulinaryRecipesEnum>
    {
        public GetCulinaryRecipesResult
            (
            GetCulinaryRecipesEnum status,
            string description,
            IEnumerable<CulinaryRecipeResponse>? culinaryRecipes
            )
            : base(status, description)
        {
            CulinaryRecipes = culinaryRecipes;
        }

        public IEnumerable<CulinaryRecipeResponse>? CulinaryRecipes { get; set; }
    }
}

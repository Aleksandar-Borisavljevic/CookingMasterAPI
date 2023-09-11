using CookingMasterAPI.Enums.CulinaryRecipeStatusEnums.CommandEnums;
using CookingMasterAPI.Enums.CulinaryRecipeStatusEnums.QueryEnums;

namespace CookingMasterAPI.Models.Result.CulinaryRecipeResult.CommandResult
{
    public class CreateCulinaryRecipeResult : BaseResult<CreateCulinaryRecipeEnum>
    {
        public CreateCulinaryRecipeResult(CreateCulinaryRecipeEnum status, string description)
            : base(status, description)
        {
        }
    }
}

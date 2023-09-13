using CookingMasterAPI.Enums.CulinaryRecipeStatusEnums.CommandEnums;

namespace CookingMasterAPI.Models.Result.CulinaryRecipeResult.CommandResult
{
    public class UpdateCulinaryRecipeResult : BaseResult<UpdateCulinaryRecipeEnum>
    {
        public UpdateCulinaryRecipeResult(UpdateCulinaryRecipeEnum status, string description)
            : base(status, description)
        {
        }
    }
}

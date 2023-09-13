using CookingMasterAPI.Enums.CulinaryRecipeStatusEnums.CommandEnums;

namespace CookingMasterAPI.Models.Result.CulinaryRecipeResult.CommandResult
{
    public class DeleteCulinaryRecipeResult : BaseResult<DeleteCulinaryRecipeEnum>
    {
        public DeleteCulinaryRecipeResult(DeleteCulinaryRecipeEnum status, string description)
            : base(status, description)
        {
        }
    }
}

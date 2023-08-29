using CookingMasterAPI.Enums.IngredientStatusEnums.CommandEnums;

namespace CookingMasterAPI.Models.Result.IngredientResult.CommandResult
{
    public class UpdateIngredientResult : BaseResult<UpdateIngredientEnum>
    {
        public UpdateIngredientResult(UpdateIngredientEnum status, string description)
            : base(status, description)
        {
        }
    }
}

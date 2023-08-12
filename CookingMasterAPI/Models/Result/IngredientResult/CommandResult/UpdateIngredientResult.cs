using CookingMasterAPI.Enums.IngredientStatusEnums.CommandEnums;

namespace CookingMasterAPI.Models.Result.IngredientResult.CommandResult
{
    public class CreateIngredientResult : BaseResult<CreateIngredientEnum>
    {
        public CreateIngredientResult(CreateIngredientEnum status, string description)
            : base(status, description)
        {
        }
    }
}

using CookingMasterAPI.Enums.IngredientStatusEnums.CommandEnums;
using CookingMasterAPI.Models.Result;

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
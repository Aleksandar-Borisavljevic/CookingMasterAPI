using CookingMasterAPI.Enums.IngredientStatusEnums.CommandEnums;

namespace CookingMasterAPI.Models.Result.IngredientResult.CommandResult
{
    public class CreateUserIngredientResult : BaseResult<CreateUserIngredientEnum>
    {
        public CreateUserIngredientResult(CreateUserIngredientEnum status, string description)
            : base(status, description)
        {
        }
    }
}

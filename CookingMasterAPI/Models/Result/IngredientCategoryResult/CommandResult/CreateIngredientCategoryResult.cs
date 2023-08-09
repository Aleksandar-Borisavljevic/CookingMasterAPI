using CookingMasterAPI.Enums.IngCategoryStatusEnums.CommandEnums;

namespace CookingMasterAPI.Models.Result.IngredientCategoryResult.CommandResult
{
    public class CreateIngredientCategoryResult : BaseResult<CreateIngredientCategoryEnum>
    {
        public CreateIngredientCategoryResult(CreateIngredientCategoryEnum status, string description)
            : base(status, description)
        {
        }
    }
}

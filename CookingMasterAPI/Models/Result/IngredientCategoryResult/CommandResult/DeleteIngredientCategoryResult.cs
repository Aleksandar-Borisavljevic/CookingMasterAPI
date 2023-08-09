using CookingMasterAPI.Enums.IngCategoryStatusEnums.CommandEnums;

namespace CookingMasterAPI.Models.Result.IngredientCategoryResult.CommandResult
{
    public class DeleteIngredientCategoryResult : BaseResult<DeleteIngredientCategoryEnum>
    {
        public DeleteIngredientCategoryResult(DeleteIngredientCategoryEnum status, string description)
            : base(status, description)
        {
        }
    }
}

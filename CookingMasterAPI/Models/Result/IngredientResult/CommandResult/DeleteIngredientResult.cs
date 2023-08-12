using CookingMasterAPI.Enums.IngredientStatusEnums.CommandEnums;

namespace CookingMasterAPI.Models.Result.IngredientResult.CommandResult
{
    public class DeleteIngredientResult : BaseResult<DeleteIngredientEnum>
    {
        public DeleteIngredientResult(DeleteIngredientEnum status, string description)
            : base(status, description)
        {
        }
    }
}

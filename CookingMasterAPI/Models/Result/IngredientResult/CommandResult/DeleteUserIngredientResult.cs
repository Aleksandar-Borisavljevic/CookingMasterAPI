using CookingMasterAPI.Enums.IngredientStatusEnums.CommandEnums;

namespace CookingMasterAPI.Models.Result.IngredientResult.CommandResult
{
    public class DeleteUserIngredientResult : BaseResult<DeleteUserIngredientEnum>
    {
        public DeleteUserIngredientResult(DeleteUserIngredientEnum status, string description)
            : base(status, description)
        {
        }
    }
}

using CookingMasterAPI.Enums.IngNutrientStatusEnums.CommandEnums;

namespace CookingMasterAPI.Models.Result.IngredientNutrientResult.CommandResult
{
    public class DeleteIngredientNutrientResult : BaseResult<DeleteIngredientNutrientEnum>
    {
        public DeleteIngredientNutrientResult(DeleteIngredientNutrientEnum status, string description)
            : base(status, description)
        {
        }
    }
}

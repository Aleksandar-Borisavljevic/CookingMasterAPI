using CookingMasterAPI.Enums.IngNutrientStatusEnums.CommandEnums;

namespace CookingMasterAPI.Models.Result.IngredientNutrientResult.CommandResult
{
    public class UpdateIngredientNutrientResult : BaseResult<UpdateIngredientNutrientEnum>
    {
        public UpdateIngredientNutrientResult(UpdateIngredientNutrientEnum status, string description) : base(status, description)
        {
        }
    }
}

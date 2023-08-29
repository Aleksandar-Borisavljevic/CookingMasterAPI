using CookingMasterAPI.Enums.IngNutrientStatusEnums.CommandEnums;

namespace CookingMasterAPI.Models.Result.IngredientNutrientResult.CommandResult
{
    public class CreateIngredientNutrientResult : BaseResult<CreateIngredientNutrientEnum>
    {
        public CreateIngredientNutrientResult(CreateIngredientNutrientEnum status, string description)
            : base(status, description)
        {
        }
    }
}

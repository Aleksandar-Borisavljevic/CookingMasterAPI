using CookingMasterAPI.Enums.IngNutrientStatusEnums.QueryEnums;
using CookingMasterAPI.Models.Response;

namespace CookingMasterAPI.Models.Result.IngredientNutrientResult.QueryResult
{
    public class GetIngredientNutrientResult : BaseResult<GetIngredientNutrientEnum>
    {
        public GetIngredientNutrientResult
            (
            GetIngredientNutrientEnum status,
            string description,
            IngredientNutrientResponse? ingredientNutrient
            )
            : base(status, description)
        {
            IngredientNutrient = ingredientNutrient;
        }

        public IngredientNutrientResponse? IngredientNutrient { get; set; }
    }
}

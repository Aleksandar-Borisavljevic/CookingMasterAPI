using CookingMasterAPI.Enums.IngredientStatusEnums.QueryEnums;
using CookingMasterAPI.Models.Response;

namespace CookingMasterAPI.Models.Result.IngredientResult.QueryResult
{
    public class GetIngredientResult : BaseResult<GetIngredientEnum>
    {
        public GetIngredientResult
            (
            GetIngredientEnum status,
            string description,
            IngredientResponse? ingredient
            )
            : base(status, description)
        {
            Ingredient = ingredient;
        }

        public IngredientResponse? Ingredient { get; set; }

    }
}

using CookingMasterAPI.Enums.IngCategoryStatusEnums.QueryEnums;
using CookingMasterAPI.Models.Response;

namespace CookingMasterAPI.Models.Result.IngredientCategoryResult.QueryResult
{
    public class GetIngredientCategoryResult : BaseResult<GetIngredientCategoryEnum>
    {
        public GetIngredientCategoryResult
            (
            GetIngredientCategoryEnum status,
            string description,
            IngredientCategoryResponse? ingredientCategory
            )
            : base(status, description)
        {
            IngredientCategory = ingredientCategory;
        }

        public IngredientCategoryResponse? IngredientCategory { get; set; }

    }
}

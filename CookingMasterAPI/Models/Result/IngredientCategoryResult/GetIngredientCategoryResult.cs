using CookingMasterAPI.Enums.IngCategoryStatusEnums;
using CookingMasterAPI.Models.Entity;
using CookingMasterAPI.Models.Response;

namespace CookingMasterAPI.Models.Result.IngredientCategoryResult
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

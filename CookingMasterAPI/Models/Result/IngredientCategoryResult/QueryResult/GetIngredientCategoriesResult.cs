using CookingMasterAPI.Enums.IngCategoryStatusEnums.QueryEnums;
using CookingMasterAPI.Models.Response;

namespace CookingMasterAPI.Models.Result.IngredientCategoryResult.QueryResult
{
    public class GetIngredientCategoriesResult : BaseResult<GetIngredientCategoriesEnum>
    {
        public GetIngredientCategoriesResult
            (
            GetIngredientCategoriesEnum status,
            string description,
            IEnumerable<IngredientCategoryResponse>? ingredientCategories
            )
            : base(status, description)
        {
            IngredientCategories = ingredientCategories;
        }

        public IEnumerable<IngredientCategoryResponse>? IngredientCategories { get; set; }
    }
}

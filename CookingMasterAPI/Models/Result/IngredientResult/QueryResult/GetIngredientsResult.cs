using CookingMasterAPI.Enums.IngredientStatusEnums.QueryEnums;
using CookingMasterAPI.Models.Response;

namespace CookingMasterAPI.Models.Result.IngredientResult.QueryResult
{
    public class GetIngredientsResult : BaseResult<GetIngredientsEnum>
    {
        public GetIngredientsResult
            (
            GetIngredientsEnum status,
            string description,
            IEnumerable<IngredientResponse>? ingredients
            )
            : base(status, description)
        {
            Ingredients = ingredients;
        }

        public IEnumerable<IngredientResponse>? Ingredients { get; set; }
    }
}

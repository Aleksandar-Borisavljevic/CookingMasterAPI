using CookingMasterAPI.Helpers;
using CookingMasterAPI.Models.Entity;
using CookingMasterAPI.Models.Request.IngredientCategoryRequests;
using CookingMasterAPI.Models.Response;

namespace CookingMasterAPI.Services.Mappers
{
    public static class IngredientCategoryMapper
    {
        public static IngredientCategoryResponse MapIngredientCategoryToResponse(IngredientCategory ingredientCategory)
        {
            return new IngredientCategoryResponse
                (
                ingredientCategory.CategoryName,
                ingredientCategory.IconPath,
                ingredientCategory.CreateDate,
                ingredientCategory.DeleteDate,
                ingredientCategory.Uid
                );
        }

        public static IngredientCategory MapRequestToIngredientCategory(CreateIngredientCategoryRequest request)
        {
            return new IngredientCategory
            {
                CategoryName = request.CategoryName,
                IconPath = request.IconPath,
                CreateDate = DateTime.Now,
                Uid = request.CategoryName.CreateUniqueSequence()
            };
        }

        public static IEnumerable<IngredientCategoryResponse> MapIngredientCategoryToResponse(IEnumerable<IngredientCategory> ingredientCategories)
        {
            return ingredientCategories.Select(MapIngredientCategoryToResponse);
        }
    }
}

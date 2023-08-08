using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using CookingMasterAPI.Data;
using CookingMasterAPI.Enums.IngCategoryStatusEnums;
using CookingMasterAPI.Helpers;
using CookingMasterAPI.Models.Entity;
using CookingMasterAPI.Models.Response;
using CookingMasterAPI.Models.Result.IngredientCategoryResult;
using CookingMasterAPI.Services.ServiceInterfaces;

namespace CookingMasterAPI.Services
{
    public class IngredientCategoryService : IIngredientCategoryService
    {
        #region Variables
        private readonly APIDbContext _context;
        #endregion
        public IngredientCategoryService(APIDbContext context)
        {
            _context = context;
        }
        public async Task<GetIngredientCategoriesResult> GetIngredientCategoriesAsync()
        {
            try
            {
                if (_context.IngredientCategories is null)
                {
                    return new GetIngredientCategoriesResult
                        (
                        GetIngredientCategoriesEnum.IngredientCategoriesNotFound,
                        GetIngredientCategoriesEnum.IngredientCategoriesNotFound.GetEnumDescription(),
                        //Enumerable.Empty<IngredientCategoryResponse>()
                        null
                        );
                }

                return new GetIngredientCategoriesResult
                        (
                        GetIngredientCategoriesEnum.Success,
                        GetIngredientCategoriesEnum.Success.GetEnumDescription(),
                        MapIngredientCategoryToResponse(await _context.IngredientCategories.Where(x => x.DeleteDate == null).ToListAsync())
                        );

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<GetIngredientCategoryResult> GetIngredientCategoryAsync(int categoryId)
        {
            //TODO: Return IngredientCategory(whole category)
            try
            {
                if (_context.IngredientCategories is null)
                {
                    return new GetIngredientCategoryResult
                        (
                        GetIngredientCategoryEnum.IngredientCategoriesNotFound,
                        GetIngredientCategoryEnum.IngredientCategoriesNotFound.GetEnumDescription(),
                        null
                        );
                }
                var ingredientCategory = await _context.IngredientCategories.FindAsync(categoryId);

                if (ingredientCategory is null)
                {
                    return new GetIngredientCategoryResult
                        (
                        GetIngredientCategoryEnum.IngredientCategoryNotFound,
                        GetIngredientCategoryEnum.IngredientCategoryNotFound.GetEnumDescription(),
                        null
                        );
                }

                return new GetIngredientCategoryResult
                        (
                        GetIngredientCategoryEnum.Success,
                        GetIngredientCategoryEnum.Success.GetEnumDescription(),
                        MapIngredientCategoryToResponse(ingredientCategory)
                        );
            }
            catch (Exception)
            {
                throw;
            }
        }

        private IEnumerable<IngredientCategoryResponse> MapIngredientCategoryToResponse(IEnumerable<IngredientCategory> ingredientCategories)
        {
            var ingredientCategoriesResponse = new List<IngredientCategoryResponse>();
            foreach (var item in ingredientCategories)
            {
                //ingredientCategoriesResponse.Add
                //    (
                //    new IngredientCategoryResponse(item.CategoryId, item.CategoryName, item.IconPath, item.CreateDate, item.DeleteDate)
                //    );
                //By using te following statement we're further optimizing this method instea of creating a new object
                ingredientCategoriesResponse.Add(MapIngredientCategoryToResponse(item));
            }
            return ingredientCategoriesResponse;
        }

        private IngredientCategoryResponse MapIngredientCategoryToResponse(IngredientCategory ingredientCategory)
        {
            return new IngredientCategoryResponse
                (
                ingredientCategory.CategoryId,
                ingredientCategory.CategoryName,
                ingredientCategory.IconPath,
                ingredientCategory.CreateDate,
                ingredientCategory.DeleteDate
                );
        }
    }
}

using CookingMasterAPI.Data;
using CookingMasterAPI.Enums.IngCategoryStatusEnums;
using CookingMasterAPI.Helpers;
using CookingMasterAPI.Models.Entity;
using CookingMasterAPI.Models.Result.IngredientCategoryResult;
using CookingMasterAPI.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

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
                        null
                        );
                }

                return new GetIngredientCategoriesResult
                        (
                        GetIngredientCategoriesEnum.Success,
                        GetIngredientCategoriesEnum.Success.GetEnumDescription(),
                        await _context.IngredientCategories.Where(x => x.DeleteDate == null).ToListAsync()
                        );

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IngredientCategory GetIngredientCategory(int categoryId)
        {
            //TODO: Return IngredientCategory(whole category)
            throw new NotImplementedException();
        }
    }
}

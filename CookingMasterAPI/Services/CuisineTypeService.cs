using CookingMasterAPI.Data;
using CookingMasterAPI.Enums.CuisineTypeEnums.QueryEnums;
using CookingMasterAPI.Enums.IngCategoryStatusEnums.QueryEnums;
using CookingMasterAPI.Helpers;
using CookingMasterAPI.Models.Request.IngredientCategoryRequests;
using CookingMasterAPI.Models.Response;
using CookingMasterAPI.Models.Result.CuisineTypeResult.QueryResult;
using CookingMasterAPI.Models.Result.IngredientCategoryResult.QueryResult;
using CookingMasterAPI.Services.Mappers;
using CookingMasterAPI.Services.ServiceInterfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CookingMasterAPI.Services
{
    public class CuisineTypeService : ICuisineTypeService
    {
        private readonly APIDbContext _context;
        //private readonly IValidator<CreateIngredientCategoryRequest> _createIngredientCategoryValidator;

        public CuisineTypeService
            (
            APIDbContext context
            //IValidator<CreateIngredientCategoryRequest> createIngredientCategoryValidator
            )
        {
            _context = context;
            //_createIngredientCategoryValidator = createIngredientCategoryValidator;
        }

        public async Task<GetCuisineTypesResult> GetCuisineTypesAsync()
        {
            try
            {
                if (_context.CuisineTypes is null)
                {
                    return new GetCuisineTypesResult
                        (
                        GetCuisineTypesEnum.CuisineTypesNotFound,
                        GetCuisineTypesEnum.CuisineTypesNotFound.GetEnumDescription(),
                        Enumerable.Empty<CuisineTypeResponse>()
                        );
                }

                return new GetCuisineTypesResult
                (
                        GetCuisineTypesEnum.Success,
                        GetCuisineTypesEnum.Success.GetEnumDescription(),
                        CuisineTypeMapper.MapCuisineTypesToResponse(await _context.CuisineTypes.ToListAsync())                        
                        );
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

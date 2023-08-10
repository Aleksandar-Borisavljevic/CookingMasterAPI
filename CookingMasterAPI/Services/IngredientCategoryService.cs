using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.Results;
using CookingMasterAPI.Data;
using CookingMasterAPI.Helpers;
using CookingMasterAPI.Models.Entity;
using CookingMasterAPI.Models.Response;
using CookingMasterAPI.Services.ServiceInterfaces;
using CookingMasterAPI.Models.Result.IngredientCategoryResult.QueryResult;
using CookingMasterAPI.Enums.IngCategoryStatusEnums.QueryEnums;
using CookingMasterAPI.Models.Result.IngredientCategoryResult.CommandResult;
using CookingMasterAPI.Models.Request.IngredientCategoryRequests;
using CookingMasterAPI.Enums.IngCategoryStatusEnums.CommandEnums;

namespace CookingMasterAPI.Services
{
    public class IngredientCategoryService : IIngredientCategoryService
    {
        #region Variables
        private readonly APIDbContext _context;
        private readonly IValidator<CreateIngredientCategoryRequest> _createIngredientCategoryValidator;
        #endregion
        public IngredientCategoryService
            (
            APIDbContext context,
            IValidator<CreateIngredientCategoryRequest> createIngredientCategoryValidator
            )
        {
            _context = context;
            _createIngredientCategoryValidator = createIngredientCategoryValidator;
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

        public async Task<GetIngredientCategoryResult> GetIngredientCategoryAsync(string uid)
        {
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
                var ingredientCategory = await _context.IngredientCategories.SingleOrDefaultAsync(c => c.Uid == uid);

                if (ingredientCategory is null)
                {
                    return new GetIngredientCategoryResult
                        (
                        GetIngredientCategoryEnum.IngredientCategoryNotFound,
                        GetIngredientCategoryEnum.IngredientCategoryNotFound.GetEnumDescription(),
                        null
                        );
                }

                if (ingredientCategory.DeleteDate is not null)
                {
                    return new GetIngredientCategoryResult
                        (
                        GetIngredientCategoryEnum.IngredientCategoryIsDeleted,
                        GetIngredientCategoryEnum.IngredientCategoryIsDeleted.GetEnumDescription(),
                        MapIngredientCategoryToResponse(ingredientCategory)
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

        public async Task<CreateIngredientCategoryResult> CreateIngredientCategoryAsync(CreateIngredientCategoryRequest request)
        {
            try
            {
                if (request is null)
                {
                    return new CreateIngredientCategoryResult
                    (
                        CreateIngredientCategoryEnum.RequestIsNull,
                        CreateIngredientCategoryEnum.RequestIsNull.GetEnumDescription()
                    );
                }

                if (await _context.IngredientCategories.AnyAsync(c => c.CategoryName == request.CategoryName && c.DeleteDate == null))
                {
                    return new CreateIngredientCategoryResult
                        (
                        CreateIngredientCategoryEnum.RecordAlreadyExists,
                        CreateIngredientCategoryEnum.RecordAlreadyExists.GetEnumDescription()
                        );
                }

                ValidationResult validationResult = _createIngredientCategoryValidator.Validate(request);
                if (!validationResult.IsValid)
                {
                    return new CreateIngredientCategoryResult
                        (
                        CreateIngredientCategoryEnum.RequestIsValid,
                        String.Join('\n', validationResult.Errors)
                        );
                }

                var result = MapRequestToIngredientCategory(request);

                _context.IngredientCategories.Add(result);

                await _context.SaveChangesAsync();

                return new CreateIngredientCategoryResult
                    (
                        CreateIngredientCategoryEnum.Success,
                        CreateIngredientCategoryEnum.Success.GetEnumDescription()
                    );
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DeleteIngredientCategoryResult> DeleteIngredientCategoryAsync(string uid)
        {
            try
            {
                if (_context.IngredientCategories is null)
                {
                    return new DeleteIngredientCategoryResult
                        (
                        DeleteIngredientCategoryEnum.IngredientCategoriesNotFound,
                        DeleteIngredientCategoryEnum.IngredientCategoriesNotFound.GetEnumDescription()
                        );
                }
                var ingredientCategory = await _context.IngredientCategories.SingleOrDefaultAsync(c => c.Uid == uid);

                if (ingredientCategory is null)
                {
                    return new DeleteIngredientCategoryResult
                        (
                        DeleteIngredientCategoryEnum.IngredientCategoryNotFound,
                        DeleteIngredientCategoryEnum.IngredientCategoryNotFound.GetEnumDescription()
                        );
                }

                //Soft Delete - example
                ingredientCategory.DeleteDate = DateTime.Now;

                //Permanent Delete - example
                //_context.IngredientCategories.Remove(ingredientCategory);

                await _context.SaveChangesAsync();

                return new DeleteIngredientCategoryResult
                        (
                        DeleteIngredientCategoryEnum.Success,
                        DeleteIngredientCategoryEnum.Success.GetEnumDescription()
                        );

            }
            catch (Exception)
            {

                throw;
            }
        }

        #region Mapping Methods - later on consider making a static class to migrate these methods to
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
                ingredientCategory.CategoryName,
                ingredientCategory.IconPath,
                ingredientCategory.CreateDate,
                ingredientCategory.DeleteDate,
                ingredientCategory.Uid
                );
        }

        private IngredientCategory MapRequestToIngredientCategory(CreateIngredientCategoryRequest request)
        {
            return new IngredientCategory
            {
                CategoryName = request.CategoryName,
                IconPath = request.IconPath,
                CreateDate = DateTime.Now,
                Uid = request.CategoryName.CreateUniqueSequence()
            };
        }
        #endregion
    }
}

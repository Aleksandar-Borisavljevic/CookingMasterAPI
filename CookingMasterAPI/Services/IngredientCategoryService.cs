using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;
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
using CookingMasterAPI.Services.Mappers;

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
                        IngredientCategoryMapper.MapIngredientCategoryToResponse(await _context.IngredientCategories.Where(x => x.DeleteDate == null).ToListAsync())
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
                        IngredientCategoryMapper.MapIngredientCategoryToResponse(ingredientCategory)
                        );
                }


                return new GetIngredientCategoryResult
                        (
                        GetIngredientCategoryEnum.Success,
                        GetIngredientCategoryEnum.Success.GetEnumDescription(),
                        IngredientCategoryMapper.MapIngredientCategoryToResponse(ingredientCategory)
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

                var result = IngredientCategoryMapper.MapRequestToIngredientCategory(request);

                await _context.IngredientCategories.AddAsync(result);

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

                if (string.IsNullOrWhiteSpace(uid))
                {
                    return new DeleteIngredientCategoryResult
                        (
                        DeleteIngredientCategoryEnum.UidIsNull,
                        DeleteIngredientCategoryEnum.UidIsNull.GetEnumDescription()
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

        public async Task<UpdateIngredientCategoryResult> UpdateIngredientCategoryAsync(string uid, JsonPatchDocument<IngredientCategory> request)
        {
            try
            {
                if (uid is null)
                {
                    return new UpdateIngredientCategoryResult
                    (
                        UpdateIngredientCategoryEnum.RequestIsNull,
                        UpdateIngredientCategoryEnum.RequestIsNull.GetEnumDescription()
                    );
                }

                if (request is null)
                {
                    return new UpdateIngredientCategoryResult
                    (
                        UpdateIngredientCategoryEnum.RequestIsNull,
                        UpdateIngredientCategoryEnum.RequestIsNull.GetEnumDescription()
                    );
                }

                var result = await _context.IngredientCategories.SingleOrDefaultAsync(c => c.Uid == uid);

                if (result == null)
                {
                    return new UpdateIngredientCategoryResult
                    (
                        UpdateIngredientCategoryEnum.NotFound,
                        UpdateIngredientCategoryEnum.NotFound.GetEnumDescription()
                    );
                }

                request.ApplyTo(result);

                await _context.SaveChangesAsync();

                return new UpdateIngredientCategoryResult
                    (
                        UpdateIngredientCategoryEnum.Success,
                        UpdateIngredientCategoryEnum.Success.GetEnumDescription()
                    );

            }
            catch (Exception ex)
            {
                return new UpdateIngredientCategoryResult
                    (
                        UpdateIngredientCategoryEnum.Undefined,
                        UpdateIngredientCategoryEnum.Undefined.GetEnumDescription() + ex.Message
                    );
            }
        }
    }
}

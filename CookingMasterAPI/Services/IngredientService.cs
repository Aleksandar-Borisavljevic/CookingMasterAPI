using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.Results;
using CookingMasterAPI.Data;
using CookingMasterAPI.Enums.IngredientStatusEnums.CommandEnums;
using CookingMasterAPI.Models.Entity;
using CookingMasterAPI.Models.Request.IngredientRequests;
using CookingMasterAPI.Models.Result.IngredientResult.CommandResult;
using CookingMasterAPI.Models.Result.IngredientResult.QueryResult;
using CookingMasterAPI.Services.ServiceInterfaces;
using CookingMasterAPI.Helpers;
using CookingMasterAPI.Enums.IngredientStatusEnums.QueryEnums;
using CookingMasterAPI.Models.Response;

namespace CookingMasterAPI.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly APIDbContext _context;
        private readonly IValidator<CreateIngredientRequest> _createIngredientValidator;

        public IngredientService
            (
            APIDbContext context,
            IValidator<CreateIngredientRequest> createIngredientValidator
            )
        {
            _context = context;
            _createIngredientValidator = createIngredientValidator;
        }
        public async Task<CreateIngredientResult> CreateIngredientAsync(CreateIngredientRequest request)
        {
            try
            {
                if (request is null)
                {
                    return new CreateIngredientResult
                    (
                        CreateIngredientEnum.RequestIsNull,
                        CreateIngredientEnum.RequestIsNull.GetEnumDescription()
                    );
                }

                if (await _context.Ingredients.AnyAsync(c => c.IngredientName == request.IngredientName && c.DeleteDate == null))
                {
                    return new CreateIngredientResult
                        (
                        CreateIngredientEnum.RecordAlreadyExists,
                        CreateIngredientEnum.RecordAlreadyExists.GetEnumDescription()
                        );
                }

                ValidationResult validationResult = _createIngredientValidator.Validate(request);

                if (!validationResult.IsValid)
                {
                    return new CreateIngredientResult
                        (
                        CreateIngredientEnum.RequestIsValid,
                        String.Join('\n', validationResult.Errors)
                        );
                }

                var result = await MapRequestToIngredientAsync(request);

                await _context.Ingredients.AddAsync(result);

                await _context.SaveChangesAsync();

                return new CreateIngredientResult
                        (
                        CreateIngredientEnum.Success,
                        CreateIngredientEnum.Success.GetEnumDescription()
                        );

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DeleteIngredientResult> DeleteIngredientAsync(string uid)
        {
            try
            {
                if (_context.Ingredients is null)
                {
                    return new DeleteIngredientResult
                        (
                        DeleteIngredientEnum.IngredientsNotFound,
                        DeleteIngredientEnum.IngredientsNotFound.GetEnumDescription()
                        );
                }

                if (string.IsNullOrWhiteSpace(uid))
                {
                    return new DeleteIngredientResult
                        (
                        DeleteIngredientEnum.UidIsNull,
                        DeleteIngredientEnum.UidIsNull.GetEnumDescription()
                        );
                }

                var ingredient = await _context.Ingredients.SingleOrDefaultAsync(c => c.Uid == uid);


                if (ingredient is null)
                {
                    return new DeleteIngredientResult
                        (
                        DeleteIngredientEnum.IngredientNotFound,
                        DeleteIngredientEnum.IngredientNotFound.GetEnumDescription()
                        );
                }

                ingredient.DeleteDate = DateTime.Now;

                await _context.SaveChangesAsync();

                return new DeleteIngredientResult
                        (
                        DeleteIngredientEnum.Success,
                        DeleteIngredientEnum.Success.GetEnumDescription()
                        );

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetIngredientResult> GetIngredientAsync(string uid)
        {
            try
            {
                if (_context.Ingredients is null)
                {
                    return new GetIngredientResult
                        (
                        GetIngredientEnum.IngredientsNotFound,
                        GetIngredientEnum.IngredientsNotFound.GetEnumDescription(),
                        null
                        );
                }

                if (string.IsNullOrWhiteSpace(uid))
                {
                    return new GetIngredientResult
                        (
                        GetIngredientEnum.UidIsNull,
                        GetIngredientEnum.UidIsNull.GetEnumDescription(),
                        null
                        );
                }

                var result = await _context.Ingredients.SingleOrDefaultAsync(x => x.Uid == uid);

                if (result is null)
                {
                    return new GetIngredientResult
                        (
                        GetIngredientEnum.IngredientNotFound,
                        GetIngredientEnum.IngredientNotFound.GetEnumDescription(),
                        null
                        );
                }

                if (result.DeleteDate is not null)
                {
                    return new GetIngredientResult
                        (
                        GetIngredientEnum.IngredientIsDeleted,
                        GetIngredientEnum.IngredientIsDeleted.GetEnumDescription(),
                        MapIngredientToResponse(result)
                        );
                }

                return new GetIngredientResult
                        (
                        GetIngredientEnum.Success,
                        GetIngredientEnum.Success.GetEnumDescription(),
                        MapIngredientToResponse(result)
                        );
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<GetIngredientsResult> GetIngredientsAsync()
        {
            try
            {
                if (_context.Ingredients is null)
                {
                    return new GetIngredientsResult
                        (
                        GetIngredientsEnum.IngredientsNotFound,
                        GetIngredientsEnum.IngredientsNotFound.GetEnumDescription(),
                        null
                        );
                }

                return new GetIngredientsResult
                        (
                        GetIngredientsEnum.Success,
                        GetIngredientsEnum.Success.GetEnumDescription(),
                        MapIngredientToResponse(await _context.Ingredients.Include(x => x.IngredientCategory).Where(i => i.DeleteDate == null).ToListAsync())
                        );
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<UpdateIngredientResult> UpdateIngredientAsync(string uid, JsonPatchDocument<Ingredient> request)
        {
            try
            {
                if (uid is null)
                {
                    return new UpdateIngredientResult
                    (
                        //TODO: Change to UidIsNull
                        UpdateIngredientEnum.RequestIsNull,
                        UpdateIngredientEnum.RequestIsNull.GetEnumDescription()
                    );
                }

                if (request is null)
                {
                    return new UpdateIngredientResult
                    (
                        UpdateIngredientEnum.RequestIsNull,
                        UpdateIngredientEnum.RequestIsNull.GetEnumDescription()
                    );
                }

                var result = await _context.Ingredients.SingleOrDefaultAsync(c => c.Uid == uid);

                if (result == null)
                {
                    return new UpdateIngredientResult
                    (
                        UpdateIngredientEnum.NotFound,
                        UpdateIngredientEnum.NotFound.GetEnumDescription()
                    );
                }

                request.ApplyTo(result);

                await _context.SaveChangesAsync();

                return new UpdateIngredientResult
                    (
                        UpdateIngredientEnum.Success,
                        UpdateIngredientEnum.Success.GetEnumDescription()
                    );
            }
            catch (Exception ex)
            {
                return new UpdateIngredientResult
                    (
                        UpdateIngredientEnum.Undefined,
                        UpdateIngredientEnum.Undefined.GetEnumDescription() + ex.Message
                    );
            }
        }

        #region Mapping Methods - later on consider making a static class to migrate these methods to
        private async Task<Ingredient> MapRequestToIngredientAsync(CreateIngredientRequest request)
        {
            var ingredientCategory = await _context.IngredientCategories.SingleOrDefaultAsync(ic => ic.Uid == request.IngredientCategoryUid);

            if (ingredientCategory is null)
            {
                ingredientCategory = await _context.IngredientCategories.LastAsync(); //We're taking the last category in case no category is found
            }

            return new Ingredient
            {
                IngredientCategory = ingredientCategory,
                IngredientName = request.IngredientName,
                IconPath = request.IconPath,
                CreateDate = DateTime.Now,
                Uid = request.IngredientName.CreateUniqueSequence()
            };
        }

        private IngredientResponse MapIngredientToResponse(Ingredient ingredient)
        {
            return new IngredientResponse
                (
                ingredient.IngredientName,
                ingredient.IconPath,
                ingredient.CreateDate,
                ingredient.DeleteDate,
                MapIngredientCategoryToResponse(ingredient.IngredientCategory),
                ingredient.Uid
                );
        }

        private IEnumerable<IngredientResponse> MapIngredientToResponse(IEnumerable<Ingredient> ingredients)
        {
            var ingredientsResponse = new List<IngredientResponse>();
            foreach (var item in ingredients)
            {
                ingredientsResponse.Add(MapIngredientToResponse(item));
            }
            return ingredientsResponse;
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
        #endregion
    }
}

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
using CookingMasterAPI.Services.Mappers;
using Microsoft.AspNetCore.Http.HttpResults;

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

                var result = await IngredientMapper.MapRequestToIngredientAsync(request, _context);

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
                        IngredientMapper.MapIngredientToResponse(result)
                        );
                }

                return new GetIngredientResult
                        (
                        GetIngredientEnum.Success,
                        GetIngredientEnum.Success.GetEnumDescription(),
                        IngredientMapper.MapIngredientToResponse(result)
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
                        IngredientMapper.MapIngredientToResponse(await _context.Ingredients.Include(x => x.IngredientCategory).Where(i => i.DeleteDate == null).ToListAsync())
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
                        UpdateIngredientEnum.UidNotFound,
                        UpdateIngredientEnum.UidNotFound.GetEnumDescription()
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

                var result = await _context.Ingredients.FirstOrDefaultAsync(c => c.Uid == uid);

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

        public async Task<CreateUserIngredientResult> CreateUserIngredientAsync(string userUid, string ingredientUid)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userUid))
                {
                    return new CreateUserIngredientResult
                    (
                        CreateUserIngredientEnum.UserUidIsNull,
                        CreateUserIngredientEnum.UserUidIsNull.GetEnumDescription()
                    );
                }

                if (string.IsNullOrWhiteSpace(ingredientUid))
                {
                    return new CreateUserIngredientResult
                    (
                        CreateUserIngredientEnum.IngredientUidIsNull,
                        CreateUserIngredientEnum.IngredientUidIsNull.GetEnumDescription()
                    );
                }
                var user = await _context.Users.SingleOrDefaultAsync(u => u.Uid.Equals(userUid));
                var ingredient = await _context.Ingredients.SingleOrDefaultAsync(i => i.Uid.Equals(ingredientUid));

                if (user is null)
                {
                    return new CreateUserIngredientResult
                    (
                        CreateUserIngredientEnum.UserNotFound,
                        CreateUserIngredientEnum.UserNotFound.GetEnumDescription()
                    );
                }

                if (ingredient is null)
                {
                    return new CreateUserIngredientResult
                    (
                        CreateUserIngredientEnum.IngredientNotFound,
                        CreateUserIngredientEnum.IngredientNotFound.GetEnumDescription()
                    );
                }

                if (_context.UserIngredients.Any(x => x.Ingredient.IngredientId == ingredient.IngredientId && x.User.UserId == user.UserId))
                {
                    return new CreateUserIngredientResult
                    (
                        CreateUserIngredientEnum.UserAlreadyHasThisIngredient,
                        CreateUserIngredientEnum.UserAlreadyHasThisIngredient.GetEnumDescription()
                    );
                }

                _context.UserIngredients.Add(new UserIngredient { User = user, Ingredient = ingredient });

                await _context.SaveChangesAsync();

                return new CreateUserIngredientResult
                    (
                        CreateUserIngredientEnum.Success,
                        CreateUserIngredientEnum.Success.GetEnumDescription()
                    );
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<DeleteUserIngredientResult> DeleteUserIngredientAsync(int userId, int ingredientId)
        {
            try
            {
                if (userId is 0)
                {
                    return new DeleteUserIngredientResult
                    (
                        DeleteUserIngredientEnum.UserUidIsNull,
                        DeleteUserIngredientEnum.UserUidIsNull.GetEnumDescription()
                    );
                }
                if (ingredientId is 0)
                {
                    return new DeleteUserIngredientResult
                    (
                        DeleteUserIngredientEnum.IngredientUidIsNull,
                        DeleteUserIngredientEnum.IngredientUidIsNull.GetEnumDescription()
                    );
                }
                var userIngredient = await _context.UserIngredients
                    .SingleOrDefaultAsync(ui => ui.User.UserId == userId && ui.Ingredient.IngredientId == ingredientId);

                if (userIngredient is null)
                {
                    return new DeleteUserIngredientResult
                    (
                        DeleteUserIngredientEnum.UserIngredientNotFound,
                        DeleteUserIngredientEnum.UserIngredientNotFound.GetEnumDescription()
                    );
                }

                _context.UserIngredients.Remove(userIngredient);

                await _context.SaveChangesAsync();

                return new DeleteUserIngredientResult
                    (
                        DeleteUserIngredientEnum.Success,
                        DeleteUserIngredientEnum.Success.GetEnumDescription()
                    );

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

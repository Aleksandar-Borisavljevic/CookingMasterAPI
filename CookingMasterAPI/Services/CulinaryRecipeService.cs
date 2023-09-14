using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.Results;
using CookingMasterAPI.Data;
using CookingMasterAPI.Enums.CulinaryRecipeStatusEnums.CommandEnums;
using CookingMasterAPI.Enums.CulinaryRecipeStatusEnums.QueryEnums;
using CookingMasterAPI.Helpers;
using CookingMasterAPI.Models.Entity;
using CookingMasterAPI.Models.Request.CulinaryRecipeRequests;
using CookingMasterAPI.Models.Result.CulinaryRecipeResult.CommandResult;
using CookingMasterAPI.Models.Result.CulinaryRecipeResult.QueryResult;
using CookingMasterAPI.Services.Mappers;
using CookingMasterAPI.Services.ServiceInterfaces;

namespace CookingMasterAPI.Services
{
    public class CulinaryRecipeService : ICulinaryRecipeService
    {
        private readonly APIDbContext _context;
        private readonly IValidator<CreateCulinaryRecipeRequest> _createCulinaryRecipeValidator;

        public CulinaryRecipeService
            (
            APIDbContext context,
            IValidator<CreateCulinaryRecipeRequest> createCulinaryRecipeValidator
            )
        {
            _context = context;
            _createCulinaryRecipeValidator = createCulinaryRecipeValidator;
        }

        public async Task<CreateCulinaryRecipeResult> CreateCulinaryRecipeAsync(CreateCulinaryRecipeRequest request)
        {
            try
            {
                if (request is null)
                {
                    return new CreateCulinaryRecipeResult
                        (
                            CreateCulinaryRecipeEnum.RequestIsNull,
                            CreateCulinaryRecipeEnum.RequestIsNull.GetEnumDescription()
                        );
                }

                //if (await _context.CulinaryRecipes.AnyAsync(cr => cr.RecipeName == request.RecipeName && cr.DeleteDate == null))
                //{
                //    return new CreateCulinaryRecipeResult
                //    (
                //        CreateCulinaryRecipeEnum.CulinaryRecipeAlreadyExists,
                //        CreateCulinaryRecipeEnum.CulinaryRecipeAlreadyExists.GetEnumDescription()
                //    );
                //}

                ValidationResult validationResult = _createCulinaryRecipeValidator.Validate(request);

                if (!validationResult.IsValid)
                {
                    return new CreateCulinaryRecipeResult
                    (
                        CreateCulinaryRecipeEnum.RequestIsValid,
                        string.Join('\n', validationResult.Errors)
                    );
                }

                var culinaryRecipe = await CulinaryRecipeMapper.MapRequestToCulinaryRecipeAsync(request, _context);

                _context.CulinaryRecipes.Add(culinaryRecipe);

                var recipeId = await _context.SaveChangesAsync();

                var ingredients = _context.Ingredients.Where(i => request.IngredientUids.Contains(i.Uid));

                var recipeIngredients = ingredients.Select(i => new RecipeIngredient { CulinaryRecipe = culinaryRecipe, Ingredient = i });

                await _context.RecipeIngredients.AddRangeAsync(recipeIngredients);

                await _context.SaveChangesAsync();

                return new CreateCulinaryRecipeResult
                    (
                        CreateCulinaryRecipeEnum.Success,
                        CreateCulinaryRecipeEnum.Success.GetEnumDescription()
                    );
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetCulinaryRecipeResult> GetCulinaryRecipeAsync(string uid)
        {
            try
            {
                if (_context.CulinaryRecipes is null)
                {
                    return new GetCulinaryRecipeResult
                        (
                            GetCulinaryRecipeEnum.CulinaryRecipeNotFound,
                            GetCulinaryRecipeEnum.CulinaryRecipeNotFound.GetEnumDescription(),
                            null
                        );
                }

                if (string.IsNullOrWhiteSpace(uid))
                {
                    return new GetCulinaryRecipeResult
                        (
                            GetCulinaryRecipeEnum.UidIsNull,
                            GetCulinaryRecipeEnum.UidIsNull.GetEnumDescription(),
                            null
                        );
                }

                var result = await _context.CulinaryRecipes
                    .Include(x => x.CuisineType)
                    .Include(x => x.User)
                    .FirstOrDefaultAsync(x => x.Uid == uid);

                if (result is null)
                {
                    return new GetCulinaryRecipeResult
                        (
                            GetCulinaryRecipeEnum.CulinaryRecipeNotFound,
                            GetCulinaryRecipeEnum.CulinaryRecipeNotFound.GetEnumDescription(),
                            null
                        );
                }

                if (result.DeleteDate is not null)
                {
                    return new GetCulinaryRecipeResult
                        (
                            GetCulinaryRecipeEnum.CulinaryRecipeIsDeleted,
                            GetCulinaryRecipeEnum.CulinaryRecipeIsDeleted.GetEnumDescription(),
                            CulinaryRecipeMapper.MapCulinaryRecipeToResponse(result, _context)
                        );
                }

                return new GetCulinaryRecipeResult
                        (
                            GetCulinaryRecipeEnum.Success,
                            GetCulinaryRecipeEnum.Success.GetEnumDescription(),
                            CulinaryRecipeMapper.MapCulinaryRecipeToResponse(result, _context)
                        );

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetCulinaryRecipesResult> GetCulinaryRecipesAsync()
        {
            try
            {
                if (_context.CulinaryRecipes is null)
                {
                    return new GetCulinaryRecipesResult
                        (
                            GetCulinaryRecipesEnum.CulinaryRecipesNotFound,
                            GetCulinaryRecipesEnum.CulinaryRecipesNotFound.GetEnumDescription(),
                            null
                        );
                }
                return new GetCulinaryRecipesResult
                        (
                            GetCulinaryRecipesEnum.Success,
                            GetCulinaryRecipesEnum.Success.GetEnumDescription(),
                            CulinaryRecipeMapper.MapCulinaryRecipeToResponse(await _context.CulinaryRecipes
                            .Include(x => x.CuisineType)
                            .Include(u => u.User)
                            .Where(y => y.DeleteDate == null)
                            .ToListAsync(), _context)
                        );
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UpdateCulinaryRecipeResult> UpdateCulinaryRecipeAsync(string uid, JsonPatchDocument<CulinaryRecipe> request)
        {
            try
            {
                if (uid is null)
                {
                    return new UpdateCulinaryRecipeResult
                    (
                        UpdateCulinaryRecipeEnum.CulinaryRecipeUidIsNull,
                        UpdateCulinaryRecipeEnum.CulinaryRecipeUidIsNull.GetEnumDescription()
                    );
                }

                if (request is null)
                {
                    return new UpdateCulinaryRecipeResult
                    (
                        UpdateCulinaryRecipeEnum.RequestIsNull,
                        UpdateCulinaryRecipeEnum.RequestIsNull.GetEnumDescription()
                    );
                }

                var culinaryRecipe = await _context.CulinaryRecipes.FirstOrDefaultAsync(x => x.Uid == uid);

                if (culinaryRecipe is null)
                {
                    return new UpdateCulinaryRecipeResult
                    (
                        UpdateCulinaryRecipeEnum.CulinaryRecipeNotFound,
                        UpdateCulinaryRecipeEnum.CulinaryRecipeNotFound.GetEnumDescription()
                    );
                }

                request.ApplyTo(culinaryRecipe);

                await _context.SaveChangesAsync();

                return new UpdateCulinaryRecipeResult
                    (
                        UpdateCulinaryRecipeEnum.Success,
                        UpdateCulinaryRecipeEnum.Success.GetEnumDescription()
                    );

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DeleteCulinaryRecipeResult> DeleteCulinaryRecipeAsync(string uid)
        {
            try
            {
                if (uid is null)
                {
                    return new DeleteCulinaryRecipeResult
                        (
                            DeleteCulinaryRecipeEnum.CulinaryRecipeUidIsNull,
                            DeleteCulinaryRecipeEnum.CulinaryRecipeUidIsNull.GetEnumDescription()
                        );
                }
                var culinaryRecipe = _context.CulinaryRecipes.FirstOrDefault(x => x.Uid == uid);

                if (culinaryRecipe is null)
                {
                    return new DeleteCulinaryRecipeResult
                        (
                            DeleteCulinaryRecipeEnum.CulinaryRecipeNotFound,
                            DeleteCulinaryRecipeEnum.CulinaryRecipeNotFound.GetEnumDescription()
                        );
                }

                culinaryRecipe.DeleteDate = DateTime.Now;

                await _context.SaveChangesAsync();

                return new DeleteCulinaryRecipeResult
                        (
                            DeleteCulinaryRecipeEnum.Success,
                            DeleteCulinaryRecipeEnum.Success.GetEnumDescription()
                        );

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

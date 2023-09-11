using CookingMasterAPI.Data;
using CookingMasterAPI.Enums.CulinaryRecipeStatusEnums.CommandEnums;
using CookingMasterAPI.Enums.CulinaryRecipeStatusEnums.QueryEnums;
using CookingMasterAPI.Enums.IngredientStatusEnums.QueryEnums;
using CookingMasterAPI.Helpers;
using CookingMasterAPI.Models.Entity;
using CookingMasterAPI.Models.Request.CulinaryRecipeRequests;
using CookingMasterAPI.Models.Result.CulinaryRecipeResult.CommandResult;
using CookingMasterAPI.Models.Result.CulinaryRecipeResult.QueryResult;
using CookingMasterAPI.Models.Result.IngredientResult.QueryResult;
using CookingMasterAPI.Services.Mappers;
using CookingMasterAPI.Services.ServiceInterfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CookingMasterAPI.Services
{
    public class CulinaryRecipeService : ICulinaryRecipeService
    {
        private readonly APIDbContext _context;
        //private readonly IValidator<CreateCulinaryRecipeRequest> _createCulinaryRecipeValidator;

        public CulinaryRecipeService
            (
            APIDbContext context
            //IValidator<CreateCulinaryRecipeRequest> createCulinaryRecipeValidator
            )
        {
            _context = context;
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
                //TODO: Implement Validation here for Creation of Culinary Recipe

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
    }
}

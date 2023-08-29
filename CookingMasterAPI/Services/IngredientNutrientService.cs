
using CookingMasterAPI.Data;
using CookingMasterAPI.Enums.IngNutrientStatusEnums.CommandEnums;
using CookingMasterAPI.Helpers;
using CookingMasterAPI.Models.Request.IngredientRequests;
using CookingMasterAPI.Models.Result.IngredientNutrientResult.CommandResult;
using CookingMasterAPI.Services.Mappers;
using CookingMasterAPI.Services.ServiceInterfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CookingMasterAPI.Services
{
    public class IngredientNutrientService : IIngredientNutrientService
    {
        private readonly APIDbContext _context;
        private readonly IValidator<CreateIngredientRequest> _createIngredientValidator;

        public IngredientNutrientService
            (
            APIDbContext context
            //IValidator<CreateIngredientNutrientRequest> createIngredientNutrientValidator
            )
        {
            _context = context;
            //_createIngredientNutrientValidator = createIngredientNutrientValidator;
        }
        public async Task<CreateIngredientNutrientResult> CreateIngredientNutrientsAsync(CreateIngredientNutrientRequest request)
        {
            try
            {

                if (request == null)
                {
                    return new CreateIngredientNutrientResult
                    (
                        CreateIngredientNutrientEnum.RequestIsNull,
                        CreateIngredientNutrientEnum.RequestIsNull.GetEnumDescription()
                    );
                }
                //TODO: Finish Fluent validation

                var result = await IngredientNutrientMapper.MapRequestToIngredientNutrientAsync(request, _context);
                if (result == null)
                {
                    return new CreateIngredientNutrientResult
                    (
                        CreateIngredientNutrientEnum.ResultIsNull,
                        CreateIngredientNutrientEnum.ResultIsNull.GetEnumDescription()
                    );
                }

                _context.IngredientNutrients.Add(result);

                await _context.SaveChangesAsync();

                return new CreateIngredientNutrientResult
                    (
                        CreateIngredientNutrientEnum.Success,
                        CreateIngredientNutrientEnum.Success.GetEnumDescription()
                    );

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

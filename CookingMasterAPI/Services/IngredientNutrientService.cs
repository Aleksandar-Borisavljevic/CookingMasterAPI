
using CookingMasterAPI.Data;
using CookingMasterAPI.Enums.IngNutrientStatusEnums.CommandEnums;
using CookingMasterAPI.Enums.IngredientStatusEnums.CommandEnums;
using CookingMasterAPI.Helpers;
using CookingMasterAPI.Models.Request.IngredientRequests;
using CookingMasterAPI.Models.Result.IngredientNutrientResult.CommandResult;
using CookingMasterAPI.Models.Result.IngredientResult.CommandResult;
using CookingMasterAPI.Services.Mappers;
using CookingMasterAPI.Services.ServiceInterfaces;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace CookingMasterAPI.Services
{
    public class IngredientNutrientService : IIngredientNutrientService
    {
        private readonly APIDbContext _context;
        private readonly IValidator<CreateIngredientNutrientRequest> _createIngredientNutrientValidator;

        public IngredientNutrientService
            (
            APIDbContext context,
            IValidator<CreateIngredientNutrientRequest> createIngredientNutrientValidator
            )
        {
            _context = context;
            _createIngredientNutrientValidator = createIngredientNutrientValidator;
        }

        //TODO: Consult with sensei whether these validations are up to his standards
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

                if (await _context.IngredientNutrients.AnyAsync(x => x.Uid == request.IngredientUid && x.DeleteDate == null))
                {
                    return new CreateIngredientNutrientResult
                        (
                        CreateIngredientNutrientEnum.IngredientNutrientsAlreadyExist,
                        CreateIngredientNutrientEnum.IngredientNutrientsAlreadyExist.GetEnumDescription()
                        );
                }

                ValidationResult validationResult = _createIngredientNutrientValidator.Validate(request);

                if (!validationResult.IsValid)
                {
                    return new CreateIngredientNutrientResult
                        (
                        CreateIngredientNutrientEnum.RequestIsValid,
                        String.Join('\n', validationResult.Errors)
                        );
                }

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

using CookingMasterAPI.Data;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.Results;
using CookingMasterAPI.Enums.IngNutrientStatusEnums.CommandEnums;
using CookingMasterAPI.Helpers;
using CookingMasterAPI.Models.Result.IngredientNutrientResult.CommandResult;
using CookingMasterAPI.Services.Mappers;
using CookingMasterAPI.Services.ServiceInterfaces;
using CookingMasterAPI.Models.Request.IngredientNutrientRequests;
using CookingMasterAPI.Models.Result.IngredientNutrientResult.QueryResult;
using CookingMasterAPI.Enums.IngredientStatusEnums.QueryEnums;
using CookingMasterAPI.Models.Result.IngredientResult.QueryResult;
using CookingMasterAPI.Enums.IngNutrientStatusEnums.QueryEnums;

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

        public async Task<GetIngredientNutrientResult> GetIngredientNutrientAsync(string uid)
        {
            try
            {
                if (_context.IngredientNutrients is null)
                {
                    return new GetIngredientNutrientResult
                        (
                        GetIngredientNutrientEnum.IngredientNutrientNotFound,
                        GetIngredientNutrientEnum.IngredientNutrientNotFound.GetEnumDescription(),
                        null
                        );
                }

                if (string.IsNullOrWhiteSpace(uid))
                {
                    return new GetIngredientNutrientResult
                        (
                        GetIngredientNutrientEnum.UidIsNull,
                        GetIngredientNutrientEnum.UidIsNull.GetEnumDescription(),
                        null
                        );
                }

                var result = await _context.IngredientNutrients.SingleOrDefaultAsync(x => x.Uid == uid);

                if (result is null)
                {
                    return new GetIngredientNutrientResult
                        (
                        GetIngredientNutrientEnum.IngredientNutrientNotFound,
                        GetIngredientNutrientEnum.IngredientNutrientNotFound.GetEnumDescription(),
                        null
                        );
                }

                if (result.DeleteDate is not null)
                {
                    return new GetIngredientNutrientResult
                        (
                        GetIngredientNutrientEnum.IngredientNutrientIsDeleted,
                        GetIngredientNutrientEnum.IngredientNutrientIsDeleted.GetEnumDescription(),
                        IngredientNutrientMapper.MapIngredientNutrientToResponse(result)
                        );
                }

                return new GetIngredientNutrientResult
                        (
                        GetIngredientNutrientEnum.Success,
                        GetIngredientNutrientEnum.Success.GetEnumDescription(),
                        IngredientNutrientMapper.MapIngredientNutrientToResponse(result)
                        );
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}

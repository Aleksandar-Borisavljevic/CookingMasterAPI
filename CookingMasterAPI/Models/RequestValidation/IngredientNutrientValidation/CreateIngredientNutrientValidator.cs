using CookingMasterAPI.Models.Entity;
using CookingMasterAPI.Models.Request.IngredientRequests;
using FluentValidation;
using Newtonsoft.Json.Linq;

namespace CookingMasterAPI.Models.RequestValidation.IngredientNutrientValidation
{
    public class CreateIngredientNutrientValidator : AbstractValidator<CreateIngredientNutrientRequest>
    {
        public CreateIngredientNutrientValidator()
        {
            RuleFor(ingredientNutrient => ingredientNutrient.Calories)
                .NotEmpty().WithMessage("Calories value is required.")
                .InclusiveBetween(0, 1000).WithMessage("Calories value must be between 0 and 1000.");

            RuleFor(ingredientNutrient => ingredientNutrient.Protein)
                .NotEmpty().WithMessage("Protein value is required.")
                .InclusiveBetween(0, 100).WithMessage("Protein value must be between 0 and 100.");

            RuleFor(ingredientNutrient => ingredientNutrient.Carbohydrates)
                .NotEmpty().WithMessage("Carbohydrates value is required.")
                .InclusiveBetween(0, 100).WithMessage("Carbohydrates value must be between 0 and 100.");

            RuleFor(ingredientNutrient => ingredientNutrient.Fat)
                .NotEmpty().WithMessage("Fat value is required.")
                .InclusiveBetween(0, 100).WithMessage("Fat value must be between 0 and 100.");

            RuleFor(ingredientNutrient => ingredientNutrient.Fat)
                .NotEmpty().WithMessage("Fat value is required.")
                .InclusiveBetween(0, 100).WithMessage("Fat value must be between 0 and 100.");

            RuleFor(ingredientNutrient => ingredientNutrient.Sugar)
                .NotEmpty().WithMessage("Sugar value is required.")
                .InclusiveBetween(0, 100).WithMessage("Sugar value must be between 0 and 100.");
        }
    }
}

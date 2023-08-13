using FluentValidation;
using CookingMasterAPI.Models.Request.IngredientRequests;
using CookingMasterAPI.Helpers;

namespace CookingMasterAPI.Models.RequestValidation.IngredientValidation
{
    public class CreateIngredientValidator : AbstractValidator<CreateIngredientRequest>
    {
        public CreateIngredientValidator()
        {
            RuleFor(ingredient => ingredient.IngredientName)
                .NotEmpty().WithMessage("Ingredient Name is required.")
                .Length(3, 50).WithMessage("Ingredient Name must be between 3 and 50 characters.")
                .Must(ExtensionMethods.HasUpperCaseLetter).WithMessage("Ingredient's Name first character must be capitol.");

            RuleFor(ingredient => ingredient.IconPath)
                .NotEmpty().WithMessage("Ingredient Icon Path is required.")
                .Length(3, 50).WithMessage("Ingredient Icon Path must be between 3 and 50 characters.");
        }
    }
}

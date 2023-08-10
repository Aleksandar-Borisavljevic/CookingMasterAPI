using FluentValidation;
using CookingMasterAPI.Models.Request.IngredientCategoryRequests;
using CookingMasterAPI.Helpers;

namespace CookingMasterAPI.Models.RequestValidation.IngredientCategoryValidation
{
    public class CreateIngredientCategoryValidator : AbstractValidator<CreateIngredientCategoryRequest>
    {
        public CreateIngredientCategoryValidator()
        {
            RuleFor(ingredientCategory => ingredientCategory.CategoryName)
                .NotEmpty().WithMessage("Ingredient Category Name is required.")
                .Length(3, 50).WithMessage("Ingredient Category Name must be between 3 and 50 characters.")
                .Must(ExtensionMethods.HasUpperCaseLetter).WithMessage("Ingredient Category's Name first character must be capitol.");

            RuleFor(ingredientCategory => ingredientCategory.IconPath)
                .NotEmpty().WithMessage("Ingredient Category Icon Path is required.")
                .Length(3, 50).WithMessage("Ingredient Category Icon Path must be between 3 and 50 characters.");
        }
    }
}

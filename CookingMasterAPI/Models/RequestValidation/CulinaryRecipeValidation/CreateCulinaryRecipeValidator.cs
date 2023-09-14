using FluentValidation;
using CookingMasterAPI.Models.Request.CulinaryRecipeRequests;

namespace CookingMasterAPI.Models.RequestValidation.CulinaryRecipeValidation
{
    public class CreateCulinaryRecipeValidator : AbstractValidator<CreateCulinaryRecipeRequest>
    {
        public CreateCulinaryRecipeValidator()
        {
            RuleFor(culinaryRecipe => culinaryRecipe.RecipeName)
                .NotEmpty().WithMessage("Culinary Recipe Name is required.")
                .Length(4, 200).WithMessage("Culinary Recipe Name must be between 4 and 200 characters.");

            RuleFor(culinaryRecipe => culinaryRecipe.RecipeDescription)
                .NotEmpty().WithMessage("Culinary Recipe Description is required.");

            RuleFor(culinaryRecipe => culinaryRecipe.CuisineTypeUid)
                .NotEmpty().WithMessage("Cuisine Type must be selected.");

            RuleFor(culinaryRecipe => culinaryRecipe.IngredientUids)
                .NotEmpty().WithMessage("Please select at least one ingredient to create a Culinary Recipe.");

        }
    }
}

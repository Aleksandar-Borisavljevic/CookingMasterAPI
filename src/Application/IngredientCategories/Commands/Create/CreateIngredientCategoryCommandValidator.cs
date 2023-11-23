
using FluentValidation;

namespace CookingMasterApi.Application.IngredientCategories.Commands.Create;
internal class CreateIngredientCategoryCommandValidator : AbstractValidator<CreateIngredientCategoryCommand>
{
    public CreateIngredientCategoryCommandValidator()
    {
        RuleFor(c => c.CategoryName)
           .NotNull()
           .NotEmpty()
           .MaximumLength(50);

        RuleFor(c => c.IconPath)
           .NotNull()
           .NotEmpty()
           .MaximumLength(50);
    }
}

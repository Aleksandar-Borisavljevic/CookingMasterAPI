using FluentValidation;

namespace CookingMasterApi.Application.Ingredients.Commands.Create;
public class CreateIngredientCommandValidator : AbstractValidator<CreateIngredientCommand>
{
    public CreateIngredientCommandValidator()
    {
        RuleFor(c => c.IngredientName)
           .NotNull()
           .NotEmpty()
           .MaximumLength(50);

        RuleFor(c => c.IconPath)
           .NotNull()
           .NotEmpty()
           .MaximumLength(50);
    }
}

using FluentValidation;


namespace CookingMasterApi.Application.File.Images.Commands;

public class UploadImageCommandValidator : AbstractValidator<UploadImageCommand>
{

    public UploadImageCommandValidator()
    {
        RuleFor(c => c.File)
           .NotNull()
           .NotEmpty();

    }
}

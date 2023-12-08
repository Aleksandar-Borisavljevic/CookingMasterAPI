using FluentValidation;


namespace CookingMasterApi.Application.File.Images.Queries;

public class GetImageQueryValidator : AbstractValidator<GetImageQuery>
{

    public GetImageQueryValidator()
    {
        RuleFor(c => c.ImageUid)
           .NotNull()
           .NotEmpty();

    }
}

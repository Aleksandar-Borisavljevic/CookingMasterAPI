using CookingMasterApi.Application.Common.Interfaces;
using FluentValidation;
using MediatR;

namespace CookingMasterApi.Application.Registration.Queries;

public record CheckIsValidEmailConfirmationCodeQuery : IRequest<bool>
{
    public string Email { get; set; }
    public string Code { get; set; }
}

public class CheckIsExternalUserQueryHandler : IRequestHandler<CheckIsValidEmailConfirmationCodeQuery, bool>
{
    private readonly IIdentityService _identityService;

    public CheckIsExternalUserQueryHandler(IIdentityService identiryService)
    {
        _identityService = identiryService;
    }

    public async Task<bool> Handle(CheckIsValidEmailConfirmationCodeQuery request, CancellationToken cancellationToken)
    {
        return await _identityService.IsEmailConfirmationCodeValid(request.Email, request.Code);
    }
}

public class CheckEmailConfirmationCodeQueryValidator : AbstractValidator<CheckIsValidEmailConfirmationCodeQuery>
{

    public CheckEmailConfirmationCodeQueryValidator()
    {
        RuleFor(c => c.Email)
           .NotNull()
           .NotEmpty()
           .EmailAddress();

        RuleFor(c => c.Code)
          .NotNull()
          .NotEmpty();

    }
}

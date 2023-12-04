using CookingMasterApi.Application.Common.Interfaces;
using FluentValidation;
using MediatR;

namespace CookingMasterApi.Application.Password.Queries;

public record CheckIsValidResetPasswordCodeQuery : IRequest<bool>
{
    public string Email { get; set; }
    public string Code { get; set; }
}

public class CheckIsExternalUserQueryHandler : IRequestHandler<CheckIsValidResetPasswordCodeQuery, bool>
{
    private readonly IIdentityService _identityService;

    public CheckIsExternalUserQueryHandler(IIdentityService identiryService)
    {
        _identityService = identiryService;
    }

    public async Task<bool> Handle(CheckIsValidResetPasswordCodeQuery request, CancellationToken cancellationToken)
    {
        return await _identityService.IsResetPasswordCodeValid(request.Email, request.Code);
    }
}

public class CheckEmailConfirmationCodeQueryValidator : AbstractValidator<CheckIsValidResetPasswordCodeQuery>
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

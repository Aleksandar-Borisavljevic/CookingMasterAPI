using CookingMasterApi.Application.Common.Interfaces;
using FluentValidation;
using MediatR;

namespace CookingMasterApi.Application.Password.Queries;

public record CheckResetPasswordCodeQuery : IRequest<CheckResetPasswordCodeQueryResult>
{
    public string Email { get; set; }
    public string Code { get; set; }
}

public class CheckResetPasswordCodeQueryHandler : IRequestHandler<CheckResetPasswordCodeQuery, CheckResetPasswordCodeQueryResult>
{
    private readonly IIdentityService _identityService;

    public CheckResetPasswordCodeQueryHandler(IIdentityService identiryService)
    {
        _identityService = identiryService;
    }

    public async Task<CheckResetPasswordCodeQueryResult> Handle(CheckResetPasswordCodeQuery request, CancellationToken cancellationToken)
    {
       var isValid = await _identityService.IsResetPasswordCodeValid(request.Email, request.Code);
        return new CheckResetPasswordCodeQueryResult { IsValid = isValid };
    }
}

public class CheckResetPasswordCodeQueryResult
{
    public bool IsValid { get; set; }
}

public class CheckResetPasswordCodeQueryValidator : AbstractValidator<CheckResetPasswordCodeQuery>
{

    public CheckResetPasswordCodeQueryValidator()
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

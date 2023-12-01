using MediatR;
using CookingMasterApi.Application.Common.Interfaces;
using CookingMasterApi.Application.Registration.Commands.SendConfirmationEmail;

namespace CookingMasterApi.Application.Registration.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand>
{
    private readonly IIdentityService _identityService;
    private readonly IMediator _mediator;

    public RegisterCommandHandler(IIdentityService identityService, IMediator mediator)
    {
        _identityService = identityService;
        _mediator = mediator;
    }

    public async Task Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await _identityService.CreateUserAsync(command.Email, command.Username, command.Password);

        await _mediator.Send(new SendConfirmationEmailCommand { Email = command.Email });
    }

}

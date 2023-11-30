using MediatR;
using CookingMasterApi.Application.Common.Interfaces;


namespace CookingMasterApi.Application.Registration.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand>
{
    private readonly IIdentityService _identityService;
    //TODO: email service;

    public RegisterCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task Handle(RegisterCommand command, CancellationToken cancellationToken)
    {

        var code = await _identityService.CreateUserAsync(command.Email, command.Username, command.Password);

        //Mail
    }

}

using MediatR;
using System;

namespace CookingMasterApi.Application.Password.Commands.ResetPassword;

public class ResetPasswordCommand : IRequest<ResetPasswordCommandResult>
{
    public string Email { get; set; }
    public string Code { get; set; }
    public string Password { get; set; }
    public string ConfirmedPassword { get; set; }

}

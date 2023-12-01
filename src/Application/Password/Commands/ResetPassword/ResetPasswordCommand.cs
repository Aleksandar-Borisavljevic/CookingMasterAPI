using CookingMasterApi.Application.Common.Interfaces;
using MediatR;

namespace CookingMasterApi.Application.Password.Commands.ResetPassword;

public class ResetPasswordCommand : IRequest<ResetPasswordCommandResult>, IContainsSensitiveData
{
    public string Email { get; set; }
    public string Code { get; set; }
    public string Password { get; set; }
    public string ConfirmedPassword { get; set; }

}

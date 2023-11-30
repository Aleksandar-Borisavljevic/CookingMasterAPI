using MediatR;

namespace CookingMasterApi.Application.Password.Commands.ChangePassword;

public class ChangePasswordCommand : IRequest
{
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }
    public string ConfirmedNewPassword { get; set; }

}

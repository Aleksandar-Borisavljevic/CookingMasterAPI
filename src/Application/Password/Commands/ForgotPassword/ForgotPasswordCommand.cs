using MediatR;

namespace CookingMasterApi.Application.Password.Commands.ForgotPassword;

public class ForgotPasswordCommand : IRequest
{
    public string Email { get; set; }
    public string ReturnUrl { get; set; }

}

using CookingMasterApi.Application.Password.Commands.ForgotPassword;
using CookingMasterApi.Application.Password.Commands.ResetPassword;
using Microsoft.AspNetCore.Mvc;

namespace CookingMasterApi.WebUI.Controllers;

public class PasswordController : ApiControllerBase
{
    [HttpPost(nameof(ForgotPassword))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }

    [HttpPost(nameof(ResetPassword))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> ResetPassword(ResetPasswordCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }

}

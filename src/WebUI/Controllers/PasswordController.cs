using CookingMasterApi.Application.Password.Commands.ChangePassword;
using CookingMasterApi.Application.Password.Commands.ForgotPassword;
using CookingMasterApi.Application.Password.Commands.ResetPassword;
using CookingMasterApi.Application.Password.Queries;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
        return Ok(await Mediator.Send(command));
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpPost(nameof(ChangePassword))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> ChangePassword(ChangePasswordCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }

    [HttpGet(nameof(IsValidResetPasswordCode))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> IsValidResetPasswordCode(string email, string code)
    {
        return Ok(await Mediator.Send(new CheckIsValidResetPasswordCodeQuery { Email = email, Code = code }));
    }

}

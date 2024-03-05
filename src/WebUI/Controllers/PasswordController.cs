using CookingMasterApi.Application.Common.Models;
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
    public async Task<ActionResult<AuthResult>> ResetPassword(ResetPasswordCommand command)
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

    [HttpGet(nameof(CheckResetPasswordCode))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CheckResetPasswordCodeQueryResult>> CheckResetPasswordCode(string email, string code)
    {
        return Ok(await Mediator.Send(new CheckResetPasswordCodeQuery { Email = email, Code = code }));
    }

}

using CookingMasterApi.Application.Password.Commands.ChangePassword;
using CookingMasterApi.Application.Password.Commands.ForgotPassword;
using CookingMasterApi.Application.Password.Commands.ResetPassword;
using CookingMasterApi.Application.Password.Queries;
using CookingMasterApi.Application.Registration.Queries;
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
        await Mediator.Send(command);
        return Ok();
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
    public async Task<IActionResult> IsValidResetPasswordCode(CheckIsValidResetPasswordCodeQuery query)
    {
        await Mediator.Send(query);
        return Ok();
    }

}

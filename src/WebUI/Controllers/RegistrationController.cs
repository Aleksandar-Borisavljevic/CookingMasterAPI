using CookingMasterApi.Application.Authentication.Commands.SignIn;
using CookingMasterApi.Application.Registration.Commands.ConfirmEmail;
using CookingMasterApi.Application.Registration.Commands.Register;
using CookingMasterApi.Application.Registration.Commands.SendConfirmationEmail;
using CookingMasterApi.Application.Registration.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CookingMasterApi.WebUI.Controllers;

public class RegistrationController : ApiControllerBase
{
    [HttpPost(nameof(Register))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Register(RegisterCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }

    [HttpPost(nameof(SendConfirmationEmail))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> SendConfirmationEmail(SendConfirmationEmailCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }

    [HttpPost(nameof(ConfirmEmail))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<SignInCommandResult>> ConfirmEmail(ConfirmEmailCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

}

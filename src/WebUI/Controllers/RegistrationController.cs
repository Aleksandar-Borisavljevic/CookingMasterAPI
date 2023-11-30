﻿using CookingMasterApi.Application.Registration.Commands.ConfirmEmail;
using CookingMasterApi.Application.Registration.Commands.Register;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CookingMasterApi.WebUI.Controllers;

public class RegistrationController : ApiControllerBase
{
    [HttpPost(nameof(Register))]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Register(RegisterCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }

    [HttpPost(nameof(ConfirmEmail))]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> ConfirmEmail(ConfirmEmailCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
}

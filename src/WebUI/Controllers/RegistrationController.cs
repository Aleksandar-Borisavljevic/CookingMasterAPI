using CookingMasterApi.Application.Authentication.Commands.Refresh;
using CookingMasterApi.Application.Authentication.Commands.Revoke;
using CookingMasterApi.Application.Authentication.Commands.SignIn;
using CookingMasterApi.Application.Registration.Commands.Register;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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

}

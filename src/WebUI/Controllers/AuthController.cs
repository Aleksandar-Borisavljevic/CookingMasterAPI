using CookingMasterApi.Application.Authentication.Commands.SignIn;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CookingMasterApi.WebUI.Controllers;

public class AuthController : ApiControllerBase
{
    [HttpPost(nameof(SignIn))]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<SignInCommandResult>> SignIn(SignInCommand command)
    {
        var result = await Mediator.Send(command);
        return Ok(result);
    }
    
}

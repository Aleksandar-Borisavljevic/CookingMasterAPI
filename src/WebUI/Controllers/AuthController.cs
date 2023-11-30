using CookingMasterApi.Application.Authentication.Commands.Refresh;
using CookingMasterApi.Application.Authentication.Commands.Revoke;
using CookingMasterApi.Application.Authentication.Commands.SignIn;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CookingMasterApi.WebUI.Controllers;

public class AuthController : ApiControllerBase
{
    [HttpPost(nameof(SignIn))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<SignInCommandResult>> SignIn(SignInCommand command)
    {
        var result = await Mediator.Send(command);
        return Ok(result);
    }

    [HttpPost(nameof(Refresh))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<RefreshCommandResult>> Refresh(RefreshCommand command)
    {
        var result = await Mediator.Send(command);
        return Ok(result);
    }

    [HttpPost(nameof(Revoke))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<ActionResult> Revoke(RevokeCommand command)
    {
        var result = await Mediator.Send(command);
        return Ok(result);
    }

}

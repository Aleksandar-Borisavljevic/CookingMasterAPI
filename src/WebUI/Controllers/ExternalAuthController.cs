using CookingMasterApi.Application.Authentication.Commands.ExternalSignIn;
using CookingMasterApi.Application.Authentication.Commands.SignIn;
using CookingMasterApi.Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CookingMasterApi.WebUI.Controllers;

public class ExternalAuthController : ApiControllerBase
{
    private readonly SignInManager<ApplicationUser> _signInManager;

    public ExternalAuthController(SignInManager<ApplicationUser> signInManager)
    {
        _signInManager = signInManager;
    }

    [HttpGet(nameof(SignIn))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult SignIn(string provider, string returnUrl)
    {
        var redirectUrl = Url.Action(nameof(SignInCallback), values: new { returnUrl });
        var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
        return new ChallengeResult(provider, properties);
    }

    [HttpGet(nameof(SignInCallback))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task SignInCallback(string returnUrl)
    {
        var result = await Mediator.Send(new ExternalSignInCommand(returnUrl));

        Response.Redirect(result.AuthReturnUrl);
    }



}

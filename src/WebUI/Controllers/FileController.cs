using System.Net.Mime;
using CookingMasterApi.Application.File.Images.Commands;
using CookingMasterApi.Application.File.Images.Queries;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CookingMasterApi.WebUI.Controllers;

public class FileController : ApiControllerBase
{


    [HttpGet(nameof(GetImage))]
    public async Task<IActionResult> GetImage(Guid imageUid)
    {
        var result = await Mediator.Send(new GetImageQuery { ImageUid = imageUid });

        Response.Headers.Add("Content-Disposition", new ContentDisposition
        {
            FileName = result.FileName,
            Inline = true
        }.ToString());

        return File(result.File, result.ContentType);
    }

    [HttpPost(nameof(UploadImage))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> UploadImage([FromForm] UploadImageCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

}

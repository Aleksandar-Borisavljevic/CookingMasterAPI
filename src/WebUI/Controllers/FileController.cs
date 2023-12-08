using System.Net.Mime;
using CookingMasterApi.Application.File.Images.Queries;
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

}

using MediatR;
using System;

namespace CookingMasterApi.Application.Authentication.Commands.Refresh;

public class RefreshCommand : IRequest<RefreshCommandResult>
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}

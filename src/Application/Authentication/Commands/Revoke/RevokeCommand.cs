using MediatR;
using System;

namespace CookingMasterApi.Application.Authentication.Commands.Revoke;

public class RevokeCommand : IRequest<Unit>
{ 
    public string RefreshToken { get; set; }
}

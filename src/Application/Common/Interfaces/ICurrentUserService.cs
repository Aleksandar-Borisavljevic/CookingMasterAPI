﻿namespace CookingMasterApi.Application.Common.Interfaces;

public interface ICurrentUserService
{
    string UserId { get; }
    string Username { get; }
    string Email { get; }
}

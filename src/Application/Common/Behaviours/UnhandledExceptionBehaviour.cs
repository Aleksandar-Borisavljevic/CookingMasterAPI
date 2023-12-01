using CookingMasterApi.Application.Common.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CookingMasterApi.Application.Common.Behaviours;

public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly ILogger<TRequest> _logger;
    private readonly ICurrentUserService _currentUserService;

    public UnhandledExceptionBehaviour(ILogger<TRequest> logger, ICurrentUserService currentUserService)
    {
        _logger = logger;
        _currentUserService = currentUserService;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception ex)
        {
            var requestName = typeof(TRequest).Name;

            if (request is IContainsSensitiveData)
            {
                _logger.LogError(ex, "CookingMasterApi Request: Unhandled Exception UserId = {User} for Request {Name}",
                    _currentUserService.UserId, requestName);
            }
            else
            {
                _logger.LogError(ex, "CookingMasterApi Request: Unhandled Exception UserId = {User} for Request {Name} {@Request}",
                     _currentUserService.UserId, requestName, request);
            }

            throw;
        }
    }


}

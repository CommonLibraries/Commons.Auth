using Commons.API.Auth.Authentication;
using Commons.API.Auth.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;

namespace Commons.API.Auth.Authorization;

public class AuthorizationMiddleware<TIdentity>: IMiddleware where TIdentity: class, new()
{
    private readonly IAuthorizationChecking<TIdentity> authorizationChecking;
    public AuthorizationMiddleware(IAuthorizationChecking<TIdentity> authorizationChecking)
    {
        this.authorizationChecking = authorizationChecking;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var endpoint = context.Features.Get<IEndpointFeature>()?.Endpoint;
        var attribute = endpoint?.Metadata.GetMetadata<AuthorizeAttribute>();
        if (attribute is null)
        {
            await next(context);
            return;
        }

        var authentication = context.Features.Get<IAuthenticationFeature<TIdentity>>();
        if (authentication is null)
        {
            context.Response.Clear();
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            await context.Response.WriteAsJsonAsync(new ErrorResponse()
            {
                ErrorCode = $"HTTP {StatusCodes.Status403Forbidden}",
                Message = "Access token was not provided or invalid."
            });
            return;
        }

        var pass = await authorizationChecking.Check(authentication.Identity, attribute.Permission, context.RequestAborted);

        if (!pass)
        {
            context.Response.Clear();
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            await context.Response.WriteAsJsonAsync(new ErrorResponse()
            {
                ErrorCode = $"HTTP {StatusCodes.Status403Forbidden}",
                Message = "The user didn't have required permission."
            });
            return;
        }

        await next(context);
    }
}

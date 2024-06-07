using Commons.API.Auth.Authentication;
using Commons.API.Auth.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;

namespace Commons.API.Auth.Authorization;

public interface IAuthorizationChecking<TIdentity> where TIdentity : class, new()
{
    Task<bool> Check(TIdentity identity, string permission, CancellationToken cancellationToken = default);
}

public class AuthorizationMiddleware<TIdentity> where TIdentity: class, new()
{
    private readonly RequestDelegate next;

    public AuthorizationMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context, IAuthorizationChecking<TIdentity> authorizationChecking)
    {
        var endpoint = context.Features.Get<IEndpointFeature>()?.Endpoint;
        var attribute = endpoint?.Metadata.GetMetadata<AuthorizeAttribute>();
        if (attribute is null)
        {
            await this.next(context);
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

        await this.next(context);
    }
}

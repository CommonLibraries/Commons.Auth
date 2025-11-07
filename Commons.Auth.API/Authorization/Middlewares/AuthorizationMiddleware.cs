using Commons.API.Auth.DTOs;
using Commons.Auth.API.Authentication.Contexts;
using Commons.Auth.Application.Abstractions.Authorizations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;

namespace Commons.Auth.API.Authorization.Middlewares;

public class AuthorizationMiddleware<TIdentity>: IMiddleware
{
    private readonly IAuthorizationChecking<TIdentity> authorizationChecking;
    private readonly IIdentityContext<TIdentity> identityContext;

    public AuthorizationMiddleware(
        IAuthorizationChecking<TIdentity> authorizationChecking,
        IIdentityContext<TIdentity> identityContext)
    {
        this.authorizationChecking = authorizationChecking;
        this.identityContext = identityContext;
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

        var identity = this.identityContext.Current;
        if (identity is null)
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

        var pass = await authorizationChecking.Check(identity, attribute.Permission, context.RequestAborted);

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

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;

namespace Commons.API.Auth.Authorization.Extensions;

public static class AuthorizationMiddlewareExtensions
{
    public static IApplicationBuilder UseAuthorizationMiddleware(this IApplicationBuilder builder)
    {
        builder.UseMiddleware(typeof(AuthorizationMiddleware<>));
        return builder;
    }
}

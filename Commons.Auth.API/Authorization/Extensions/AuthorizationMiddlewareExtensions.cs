using Commons.Auth.API.Authorization.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Commons.Auth.API.Authorization.Extensions;

public static class AuthorizationMiddlewareExtensions
{
    public static IAuthorizationMiddlewareServiceBuilder<TIdentity> SetupAuthorizationMiddleware<TIdentity>(this IServiceCollection services) where TIdentity : class, new()
    {
        return new DefaultAuthorizationMiddlewareServiceBuilder<TIdentity>(services);
    }

    public static IApplicationBuilder UseAuthorizationMiddleware<TIdentity>(this IApplicationBuilder builder) where TIdentity : class, new()
    {
        builder.UseMiddleware<AuthorizationMiddleware<TIdentity>>();
        return builder;
    }
}

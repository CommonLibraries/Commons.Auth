using Commons.Auth.API.Authorization.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Commons.Auth.API.Authorization.Extensions;

public static class AuthorizationMiddlewareExtensions
{
    public static IAuthorizationMiddlewareServiceBuilder<TIdentity> AddAuthorizationMiddleware<TIdentity>(this IServiceCollection services)
    {
        services.TryAddTransient<AuthorizationMiddleware<TIdentity>>();
        return new DefaultAuthorizationMiddlewareServiceBuilder<TIdentity>(services);
    }

    public static IApplicationBuilder UseAuthorizationMiddleware<TIdentity>(this IApplicationBuilder builder)
    {
        builder.UseMiddleware<AuthorizationMiddleware<TIdentity>>();
        return builder;
    }
}

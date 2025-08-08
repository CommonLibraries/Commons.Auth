using Commons.Auth.API.Authentication.Middlewares;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Commons.Auth.API.Authentication.Extensions;

public static class AuthenticationMiddlewareExtensions
{
    public static IAuthenticationMiddlewareServiceBuiler<TIdentity> SetupAuthenticationMiddleware<TIdentity>(this IServiceCollection services)
        where TIdentity : class, new()
    {
        return new DefaultAuthenticationMiddlewareServiceBuiler<TIdentity>(services);
    }

    public static IApplicationBuilder UseAuthenticationMiddleware<TIdentity>(this IApplicationBuilder builder)
        where TIdentity : class, new()
    {
        return builder.UseMiddleware<AuthenticationMiddleware<TIdentity>>();
    }
}

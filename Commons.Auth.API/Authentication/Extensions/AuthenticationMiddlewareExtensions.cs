using Commons.Auth.API.Authentication.Contexts;
using Commons.Auth.API.Authentication.Middlewares;
using Commons.Auth.Application.Abstractions.Authentication.Jwt;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Commons.Auth.API.Authentication.Extensions;

public static class AuthenticationMiddlewareExtensions
{
    public static IAuthenticationMiddlewareServiceBuiler<TIdentity> AddAuthenticationMiddleware<TIdentity>(this IServiceCollection services)
    {
        services.TryAddTransient<AuthenticationMiddleware<TIdentity>>();
        services.TryAddScoped<IJwtTokenContext>(provider => provider.GetRequiredService<IMutableJwtTokenContext>());
        services.TryAddScoped<IMutableJwtTokenContext, MutableJwtTokenContext>();
        services.TryAddScoped<IIdentityContext<TIdentity>>(provider => provider.GetRequiredService<IMutableIdentityContext<TIdentity>>());
        services.TryAddScoped<IMutableIdentityContext<TIdentity>, MutableIdentityContext<TIdentity>>();

        return new DefaultAuthenticationMiddlewareServiceBuiler<TIdentity>(services);
    }

    public static IApplicationBuilder UseAuthenticationMiddleware<TIdentity>(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<AuthenticationMiddleware<TIdentity>>();
    }
}

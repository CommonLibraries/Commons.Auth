using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Commons.API.Auth.Authentication.Extensions;

public static class AuthenticationMiddlewareExtensions
{
    public static IServiceCollection AddAuthenticationMiddleware(this IServiceCollection services)
    {
        services.TryAddSingleton(typeof(JwtAuthentication<>));
        return services;
    }

    public static IApplicationBuilder UseAuthenticationMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware(typeof(AuthenticationMiddleware<>));
    }
}

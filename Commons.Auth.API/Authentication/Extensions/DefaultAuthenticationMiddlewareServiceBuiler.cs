using Commons.Auth.API.Authentication.Middlewares;
using Commons.Auth.Application.Abstractions.Authentication.Jwt;
using Commons.Auth.Infrastructure.Authentication.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Collections;

namespace Commons.Auth.API.Authentication.Extensions;

internal class DefaultAuthenticationMiddlewareServiceBuiler<TJwtPayload> :
    IAuthenticationMiddlewareServiceBuiler<TJwtPayload>
        where TJwtPayload : class, new()
{
    private readonly IServiceCollection services;
    public DefaultAuthenticationMiddlewareServiceBuiler(IServiceCollection services)
    {
        this.services = services;
    }

    public IAuthenticationMiddlewareServiceBuiler<TJwtPayload> Done()
    {
        this.services.TryAddTransient<IJwtValidator<TJwtPayload>>();
        this.services.TryAddTransient<AuthenticationMiddleware<TJwtPayload>>();
        return this;
    }

    public IAuthenticationMiddlewareServiceBuiler<TJwtPayload>
        AddIdentityMapping<TClaimsIdentityMapping>()
            where TClaimsIdentityMapping :
                class, IJwtPayloadMapping<TJwtPayload>
    {
        this.services.TryAddTransient<IJwtPayloadMapping<TJwtPayload>, TClaimsIdentityMapping>();
        return this;
    }

    public IAuthenticationMiddlewareServiceBuiler<TJwtPayload> AddJwtOptions(IConfigurationSection configurationSection)
    {
        this.services.AddOptions<JwtOptions>()
            .Bind(configurationSection)
            .ValidateDataAnnotations()
            .ValidateOnStart();
        return this;
    }
}

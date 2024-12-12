using Commons.API.Auth.Authentication.Tokens.JWT;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Collections;

namespace Commons.API.Auth.Authentication.Extensions;

internal class DefaultAuthenticationMiddlewareServiceBuiler<TIdentity> :
    IAuthenticationMiddlewareServiceBuiler<TIdentity>
        where TIdentity : class, new()
{
    private readonly IServiceCollection services;
    public DefaultAuthenticationMiddlewareServiceBuiler(IServiceCollection services)
    {
        this.services = services;
    }

    public IAuthenticationMiddlewareServiceBuiler<TIdentity> Done()
    {
        this.services.TryAddTransient<JwtAuthentication<TIdentity>>();
        this.services.TryAddTransient<AuthenticationMiddleware<TIdentity>>();
        return this;
    }

    public IAuthenticationMiddlewareServiceBuiler<TIdentity>
        AddIdentityMapping<TClaimsIdentityMapping>()
            where TClaimsIdentityMapping :
                class, IIdentityMapping<TIdentity>
    {
        this.services.TryAddTransient<IIdentityMapping<TIdentity>, TClaimsIdentityMapping>();
        return this;
    }

    public IAuthenticationMiddlewareServiceBuiler<TIdentity>
        AddIdentityValidation<TIdentityValidation>()
            where TIdentityValidation :
                class, IIdentityValidation<TIdentity>
    {
        this.services.TryAddTransient<IIdentityValidation<TIdentity>, TIdentityValidation>();
        return this;
    }

    public IAuthenticationMiddlewareServiceBuiler<TIdentity> AddJwtOptions(IConfigurationSection configurationSection)
    {
        this.services.AddOptions<JwtOptions>()
            .Bind(configurationSection)
            .ValidateDataAnnotations()
            .ValidateOnStart();
        return this;
    }
}

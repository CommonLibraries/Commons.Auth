using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Collections;

namespace Commons.API.Auth.Authentication.Extensions;

internal class DefaultAuthenticationMiddlewareServiceBuiler<TIdentity> : IAuthenticationMiddlewareServiceBuiler<TIdentity>
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
        AddClaimsMapping<TClaimsIdentityMapping>()
            where TClaimsIdentityMapping :
                class, IClaimsIdentityMapping<TIdentity>
    {
        this.services.TryAddTransient<IClaimsIdentityMapping<TIdentity>, TClaimsIdentityMapping>();
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
}

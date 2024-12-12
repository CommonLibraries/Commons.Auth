using Microsoft.Extensions.Configuration;

namespace Commons.API.Auth.Authentication.Extensions;

public interface IAuthenticationMiddlewareServiceBuiler<TIdentity>
{
    IAuthenticationMiddlewareServiceBuiler<TIdentity> Done();
    IAuthenticationMiddlewareServiceBuiler<TIdentity> AddIdentityMapping<TClaimsIdentityMapping>()
        where TClaimsIdentityMapping : class, IIdentityMapping<TIdentity>;
    IAuthenticationMiddlewareServiceBuiler<TIdentity> AddIdentityValidation<TIdentityValidation>()
        where TIdentityValidation : class, IIdentityValidation<TIdentity>;
    IAuthenticationMiddlewareServiceBuiler<TIdentity> AddJwtOptions(IConfigurationSection configurationSection);
}

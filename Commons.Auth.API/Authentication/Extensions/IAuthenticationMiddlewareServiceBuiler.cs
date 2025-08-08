using Commons.Auth.Application.Abstractions.Authentication.Jwt;
using Microsoft.Extensions.Configuration;

namespace Commons.Auth.API.Authentication.Extensions;

public interface IAuthenticationMiddlewareServiceBuiler<TIdentity>
{
    IAuthenticationMiddlewareServiceBuiler<TIdentity> Done();
    IAuthenticationMiddlewareServiceBuiler<TIdentity> AddIdentityMapping<TClaimsIdentityMapping>()
        where TClaimsIdentityMapping : class, IJwtPayloadMapping<TIdentity>;
    IAuthenticationMiddlewareServiceBuiler<TIdentity> AddJwtOptions(IConfigurationSection configurationSection);
}

namespace Commons.API.Auth.Authentication.Extensions;

public interface IAuthenticationMiddlewareServiceBuiler<TIdentity>
{
    IAuthenticationMiddlewareServiceBuiler<TIdentity> Done();
    IAuthenticationMiddlewareServiceBuiler<TIdentity> AddClaimsMapping<TClaimsIdentityMapping>()
        where TClaimsIdentityMapping : class, IClaimsIdentityMapping<TIdentity>;
    IAuthenticationMiddlewareServiceBuiler<TIdentity> AddIdentityValidation<TIdentityValidation>()
        where TIdentityValidation : class, IIdentityValidation<TIdentity>;
}

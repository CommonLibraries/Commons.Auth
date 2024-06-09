namespace Commons.API.Auth.Authorization.Extensions;

public interface IAuthorizationMiddlewareServiceBuilder<TIdentity> where TIdentity : class, new()
{
    IAuthorizationMiddlewareServiceBuilder<TIdentity> AddAuthorizationChecking<TAuthorizationChecking>()
        where TAuthorizationChecking : class, IAuthorizationChecking<TIdentity>;
    IAuthorizationMiddlewareServiceBuilder<TIdentity> Done();
}

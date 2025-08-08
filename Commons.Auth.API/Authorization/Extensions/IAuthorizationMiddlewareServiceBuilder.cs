using Commons.Auth.API.Authorization.Middlewares;
using Microsoft.Extensions.Configuration;

namespace Commons.Auth.API.Authorization.Extensions;

public interface IAuthorizationMiddlewareServiceBuilder<TIdentity> where TIdentity : class, new()
{
    IAuthorizationMiddlewareServiceBuilder<TIdentity> AddAuthorizationChecking<TAuthorizationChecking>()
        where TAuthorizationChecking : class, IAuthorizationChecking<TIdentity>;
    IAuthorizationMiddlewareServiceBuilder<TIdentity> Done();
}

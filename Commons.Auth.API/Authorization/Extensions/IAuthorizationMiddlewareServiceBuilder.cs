using Commons.Auth.API.Authorization.Middlewares;
using Commons.Auth.Application.Abstractions.Authorizations;
using Microsoft.Extensions.Configuration;

namespace Commons.Auth.API.Authorization.Extensions;

public interface IAuthorizationMiddlewareServiceBuilder<TIdentity>
{
    IAuthorizationMiddlewareServiceBuilder<TIdentity> AddAuthorizationChecking<TAuthorizationChecking>()
        where TAuthorizationChecking : class, IAuthorizationChecking<TIdentity>;
}

using Commons.Auth.Application.Abstractions.Authorizations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Commons.Auth.API.Authorization.Extensions;

internal class DefaultAuthorizationMiddlewareServiceBuilder<TIdentity> : IAuthorizationMiddlewareServiceBuilder<TIdentity>
{
    private readonly IServiceCollection services;
    public DefaultAuthorizationMiddlewareServiceBuilder(IServiceCollection services)
    {
        this.services = services;
    }

    public IAuthorizationMiddlewareServiceBuilder<TIdentity> AddAuthorizationChecking<TAuthorizationChecking>()
        where TAuthorizationChecking: class, IAuthorizationChecking<TIdentity>
    {
        this.services.TryAddTransient<IAuthorizationChecking<TIdentity>, TAuthorizationChecking>();
        return this;
    }
}

using Commons.Auth.API.Authorization.Middlewares;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Commons.Auth.API.Authorization.Extensions;

internal class DefaultAuthorizationMiddlewareServiceBuilder<TIdentity> : IAuthorizationMiddlewareServiceBuilder<TIdentity> where TIdentity : class, new()
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

    public IAuthorizationMiddlewareServiceBuilder<TIdentity> Done()
    {
        this.services.TryAddTransient<AuthorizationMiddleware<TIdentity>>();
        return this;
    }
}

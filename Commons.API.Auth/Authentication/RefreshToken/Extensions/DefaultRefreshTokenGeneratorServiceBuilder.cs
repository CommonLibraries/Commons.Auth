using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Commons.API.Auth.Authentication.RefreshToken.Extensions;

internal class DefaultRefreshTokenGeneratorServiceBuilder : IRefreshTokenGeneratorServiceBuilder
{
    private readonly IServiceCollection services;
    public DefaultRefreshTokenGeneratorServiceBuilder(IServiceCollection services)
    {
        this.services = services;
    }

    public IRefreshTokenGeneratorServiceBuilder AddOptions(IConfigurationSection configurationSection)
    {
        services.AddOptions<RefreshTokenOptions>()
            .Bind(configurationSection)
            .ValidateDataAnnotations()
            .ValidateOnStart();
        return this;
    }

    public IServiceCollection Done()
    {
        services.TryAddTransient<RefreshTokenGenerator>();
        return services;
    }
}

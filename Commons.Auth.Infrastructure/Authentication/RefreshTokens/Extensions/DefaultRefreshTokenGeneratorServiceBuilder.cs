using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Commons.Auth.Infrastructure.Authentication.RefreshTokens.Extensions;

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
}

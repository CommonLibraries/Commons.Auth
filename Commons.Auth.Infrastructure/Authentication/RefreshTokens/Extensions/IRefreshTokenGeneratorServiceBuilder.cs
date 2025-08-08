using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Commons.Auth.Infrastructure.Authentication.RefreshTokens.Extensions;

public interface IRefreshTokenGeneratorServiceBuilder
{
    IRefreshTokenGeneratorServiceBuilder AddOptions(IConfigurationSection configurationSection);
}

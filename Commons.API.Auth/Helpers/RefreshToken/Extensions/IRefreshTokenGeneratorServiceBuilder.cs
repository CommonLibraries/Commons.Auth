using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Commons.API.Auth.Helpers.RefreshToken.Extensions;

public interface IRefreshTokenGeneratorServiceBuilder
{
    IRefreshTokenGeneratorServiceBuilder AddOptions(IConfigurationSection configurationSection);
    IServiceCollection Done();
}

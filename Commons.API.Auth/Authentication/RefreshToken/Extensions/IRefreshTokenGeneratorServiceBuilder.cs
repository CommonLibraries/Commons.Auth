using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Commons.API.Auth.Authentication.RefreshToken.Extensions;

public interface IRefreshTokenGeneratorServiceBuilder
{
    IRefreshTokenGeneratorServiceBuilder AddOptions(IConfigurationSection configurationSection);
    IServiceCollection Done();
}

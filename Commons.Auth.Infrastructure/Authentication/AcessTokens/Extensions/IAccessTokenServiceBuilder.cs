using Microsoft.Extensions.Configuration;

namespace Commons.Auth.Infrastructure.Authentication.AccessTokens.Extensions
{
    public interface IAccessTokenServiceBuilder
    {
        IAccessTokenServiceBuilder AddOptions(IConfigurationSection configurationSection);
        IAccessTokenServiceBuilder AddPayloadMapping(Type payloadMappingType);
    }
}

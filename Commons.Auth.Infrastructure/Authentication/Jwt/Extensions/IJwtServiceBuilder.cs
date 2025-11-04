using Microsoft.Extensions.Configuration;

namespace Commons.Auth.Infrastructure.Authentication.Jwt.Extensions
{
    public interface IJwtServiceBuilder
    {
        IJwtServiceBuilder AddOptions(IConfigurationSection configurationSection);
        IJwtServiceBuilder AddPayloadMapping(Type payloadMappingType);
    }
}

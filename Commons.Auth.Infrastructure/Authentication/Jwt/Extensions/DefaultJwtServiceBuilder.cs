using Commons.Auth.Application.Abstractions.Authentication.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Commons.Auth.Infrastructure.Authentication.Jwt.Extensions
{
    internal class DefaultJwtServiceBuilder : IJwtServiceBuilder
    {
        private readonly IServiceCollection services;
        public DefaultJwtServiceBuilder(IServiceCollection services)
        {
            this.services = services;
        }

        public IJwtServiceBuilder AddOptions(IConfigurationSection configurationSection)
        {
            this.services.AddOptions<JwtOptions>()
                .Bind(configurationSection)
                .ValidateDataAnnotations()
                .ValidateOnStart();
            return this;
        }

        public IJwtServiceBuilder AddPayloadMapping(Type payloadMappingType)
        {
            var theInterface = payloadMappingType.GetInterface(typeof(IJwtPayloadMapping<>).Name);
            if (theInterface is null)
            {
                throw new ArgumentException($"The type {payloadMappingType.FullName} does not implement IJwtPayloadMapping<> interface.");
            }
            
            this.services.AddTransient(theInterface, payloadMappingType);
            return this;
        }
    }
}

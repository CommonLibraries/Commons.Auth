using Commons.Auth.Application.Abstractions.Authentication.AccessTokens;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Commons.Auth.Infrastructure.Authentication.AccessTokens.Extensions
{
    internal class DefaultAccessTokenServiceBuilder : IAccessTokenServiceBuilder
    {
        private readonly IServiceCollection services;
        public DefaultAccessTokenServiceBuilder(IServiceCollection services)
        {
            this.services = services;
        }

        public IAccessTokenServiceBuilder AddOptions(IConfigurationSection configurationSection)
        {
            this.services.AddOptions<JwtOptions>()
                .Bind(configurationSection)
                .ValidateDataAnnotations()
                .ValidateOnStart();
            return this;
        }

        public IAccessTokenServiceBuilder AddPayloadMapping(Type payloadMappingType)
        {
            var theInterface = payloadMappingType.GetInterface(typeof(IAccessTokenPayloadMapping<>).Name);
            if (theInterface is null)
            {
                throw new ArgumentException($"The type {payloadMappingType.FullName} does not implement IJwtPayloadMapping<> interface.");
            }
            
            this.services.AddTransient(theInterface, payloadMappingType);
            return this;
        }
    }
}

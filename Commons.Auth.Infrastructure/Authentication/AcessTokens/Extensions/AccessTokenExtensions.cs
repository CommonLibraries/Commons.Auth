using Commons.Auth.Application.Abstractions.Authentication.AccessTokens;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Auth.Infrastructure.Authentication.AccessTokens.Extensions
{
    public static class AccessTokenExtensions
    {
        public static IAccessTokenServiceBuilder AddAccessTokenGenerator(this IServiceCollection services)
        {
            services.AddTransient(typeof(IAccessTokenGenerator<>), typeof(DefaultJwtGenerator<>));
            services.AddTransient(typeof(IAccessTokenValidator<>), typeof(JwtValidator<>));
            return new DefaultAccessTokenServiceBuilder(services);
        }
    }
}

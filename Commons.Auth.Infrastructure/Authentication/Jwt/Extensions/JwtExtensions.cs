using Commons.Auth.Application.Abstractions.Authentication.Jwt;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Auth.Infrastructure.Authentication.Jwt.Extensions
{
    public static class JwtExtensions
    {
        public static IJwtServiceBuilder AddJwtGenerator(this IServiceCollection services)
        {
            services.AddTransient(typeof(IJwtGenerator<>), typeof(DefaultJwtGenerator<>));
            services.AddTransient(typeof(IJwtValidator<>), typeof(JwtValidator<>));
            return new DefaultJwtServiceBuilder(services);
        }
    }
}

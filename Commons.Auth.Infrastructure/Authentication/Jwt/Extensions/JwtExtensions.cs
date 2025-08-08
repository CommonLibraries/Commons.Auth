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
        public static IServiceCollection AddJwt<TJwtPayload>(this IServiceCollection services)
        {
            services.AddTransient<IJwtGenerator<TJwtPayload>, JwtGenerator<TJwtPayload>>();
            services.AddTransient<IJwtValidator<TJwtPayload>, JwtValidator<TJwtPayload>>();
            return services;
        }
    }
}

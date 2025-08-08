using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Text.Json;
using Commons.Auth.Application.Abstractions.Authentication.Jwt;
using Commons.Auth.API.Authentication.Features.JwtPayloadFeature;
using Commons.Auth.API.Authentication.Features.JwtTokenFeature;

namespace Commons.Auth.API.Authentication.Middlewares
{
    public class AuthenticationMiddleware<TIdentity> : IMiddleware where TIdentity : class, new()
    {
        private readonly IJwtValidator<TIdentity> jwtValidator;

        public AuthenticationMiddleware(IJwtValidator<TIdentity> jwtValidator)
        {
            this.jwtValidator = jwtValidator;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var endpoint = context.Features.Get<IEndpointFeature>()?.Endpoint;
            var attribute = endpoint?.Metadata.GetMetadata<AuthenticateAttribute>();
            if (attribute is null)
            {
                await next(context);
                return;
            }

            var input = context.Features.Get<IJwtTokenFeature>();
            if (input is null)
            {
                await next(context);
                return;
            }

            var jwtToken = input.Token;
            if (string.IsNullOrWhiteSpace(jwtToken))
            {
                context.Response.Clear();
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsJsonAsync(new
                {
                    Message = "Access token was not provided in \"access-token\" HTTP Cookie."
                }, new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                }, context.RequestAborted);
                return;
            }

            var payload = await jwtValidator.Validate(jwtToken);

            if (payload is null)
            {
                context.Response.Clear();
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsJsonAsync(new
                {
                    Message = "Access token was invalid."
                }, new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                }, context.RequestAborted);

                return;
            }

            var authenticationFeature = new JwtPayloadFeature<TIdentity>()
            {
                Identity = payload
            };
            context.Features.Set<IJwtPayloadFeature<TIdentity>>(authenticationFeature);
            await next(context);
        }
    }
}

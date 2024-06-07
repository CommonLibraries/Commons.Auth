using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Commons.API.Auth.Authentication
{
    public class AuthenticationMiddleware<TIdentity> where TIdentity : class, new()
    {
        private readonly RequestDelegate next;
        private readonly JwtAuthentication<TIdentity> jwtAuthentication;
        private readonly IOptions<JwtOptions> jwtAuthenticationOptions;

        public AuthenticationMiddleware(
            RequestDelegate next,
            JwtAuthentication<TIdentity> jwtAuthentication,
            IOptions<JwtOptions> jwtAuthenticationOptions,
            Func<IDictionary<string, string>, TIdentity> claimsFunc)
        {
            this.next = next;
            this.jwtAuthentication = jwtAuthentication;
            this.jwtAuthenticationOptions = jwtAuthenticationOptions;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var endpoint = context.Features.Get<IEndpointFeature>()?.Endpoint;
            var attribute = endpoint?.Metadata.GetMetadata<AuthenticateAttribute>();
            if (attribute is null)
            {
                await next(context);
                return;
            }

            var jwtToken = context.Request.Cookies["access-token"];

            if (jwtToken is null)
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

            var identity = await jwtAuthentication.ValidateJwt(
                jwtToken,
                jwtAuthenticationOptions.Value.SigningKey);

            if (identity is null)
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

            var authenticationFeature = new AuthenticationFeature<TIdentity>()
            {
                Identity = identity
            };
            context.Features.Set<IAuthenticationFeature<TIdentity>>(authenticationFeature);
            await next(context);
        }
    }
}

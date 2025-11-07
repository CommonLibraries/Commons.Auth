using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Text.Json;
using Commons.Auth.Application.Abstractions.Authentication.Jwt;
using Commons.Auth.API.Authentication.Contexts;

namespace Commons.Auth.API.Authentication.Middlewares
{
    public class AuthenticationMiddleware<TIdentity> : IMiddleware
    {
        private readonly IJwtValidator<TIdentity> jwtValidator;
        private readonly IJwtTokenContext jwtTokenContext;
        private readonly IMutableIdentityContext<TIdentity> identityContext;

        public AuthenticationMiddleware(
            IJwtTokenContext jwtTokenContext,
            IJwtValidator<TIdentity> jwtValidator,
            IMutableIdentityContext<TIdentity> identityContext)
        {
            this.jwtTokenContext = jwtTokenContext;
            this.jwtValidator = jwtValidator;
            this.identityContext = identityContext;
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

            var jwtToken = this.jwtTokenContext.Current;
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

            this.identityContext.Current = payload;
            await next(context);
        }
    }
}

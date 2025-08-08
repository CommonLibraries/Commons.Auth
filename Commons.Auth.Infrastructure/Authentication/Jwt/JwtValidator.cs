using Commons.Auth.Application.Abstractions.Authentication.Jwt;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Commons.Auth.Infrastructure.Authentication.Jwt
{
    public class JwtValidator<TJwtPayload> : IJwtValidator<TJwtPayload>
    {
        private readonly JwtOptions options;
        private readonly IJwtPayloadMapping<TJwtPayload> payloadMapping;

        public JwtValidator(IOptions<JwtOptions> options, IJwtPayloadMapping<TJwtPayload> payloadMapping)
        {
            this.options = options.Value;
            this.payloadMapping = payloadMapping;
        }

        public async Task<TJwtPayload?> Validate(string token, CancellationToken cancellationToken = default)
        {
            var jwtHandler = new JsonWebTokenHandler();
            var signingKey = Encoding.ASCII.GetBytes(options.SigningKey);

            var validationResult = await jwtHandler.ValidateTokenAsync(token, new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(signingKey),
                ValidateIssuer = false,
                ValidateAudience = false
            });

            if (!validationResult.IsValid)
            {
                return default;
            }

            var payload = payloadMapping.FromClaims(
                new Dictionary<string, string>(
                    validationResult.Claims.Select(
                        item => KeyValuePair.Create(item.Key, item.Value.ToString() ?? "")
                    )
                )
            );

            return payload;
        }
    }
}

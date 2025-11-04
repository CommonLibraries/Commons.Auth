using Commons.Auth.Application.Abstractions.Authentication.Jwt;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Auth.Infrastructure.Authentication.Jwt
{
    public class DefaultJwtGenerator<TJwtPayload> : IJwtGenerator<TJwtPayload>
    {
        private readonly IJwtPayloadMapping<TJwtPayload> payloadMapping;
        private readonly JwtOptions options;

        public DefaultJwtGenerator(
            IJwtPayloadMapping<TJwtPayload> payloadMapping,
            IOptions<JwtOptions> options)
        {
            this.payloadMapping = payloadMapping;
            this.options = options.Value;
        }

        public JwtTokenDTO GenerateToken(TJwtPayload payload)
        {
            var expiration = DateTime.UtcNow + options.Lifespan;

            var claims = payloadMapping.ToClaims(payload).Select(item => new System.Security.Claims.Claim(item.Key, item.Value));

            var signingKey = Encoding.ASCII.GetBytes(options.SigningKey);
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(signingKey),
                SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new System.Security.Claims.ClaimsIdentity(claims),
                Expires = expiration,
                SigningCredentials = signingCredentials
            };

            var jwtHandler = new JsonWebTokenHandler();
            var token = jwtHandler.CreateToken(tokenDescriptor);
            return new JwtTokenDTO(token, expiration);
        }
    }
}

using System.Linq;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace Commons.API.Auth.Authentication.Tokens.JWT;

public class JwtAuthentication<TIdentity> where TIdentity : class
{
    private readonly IIdentityMapping<TIdentity> claimsIdentityMapping;
    private readonly JwtOptions options;
    public JwtAuthentication(
        IIdentityMapping<TIdentity> claimsIdentityMapping,
        IOptions<JwtOptions> options)
    {
        this.claimsIdentityMapping = claimsIdentityMapping;
        this.options = options.Value;
    }

    public JwtToken GenerateJwt(TIdentity identity)
    {
        var expiry = DateTime.UtcNow + options.Lifespan;
        return GenerateJwt(identity, options.SigningKey, expiry);
    }

    private JwtToken GenerateJwt(
        TIdentity identity,
        string plainSigningKey,
        DateTime expiration)
    {
        var jwtHandler = new JsonWebTokenHandler();

        var claims = claimsIdentityMapping.IdentityToClaims(identity).Select(item => new System.Security.Claims.Claim(item.Key, item.Value));

        var signingKey = Encoding.ASCII.GetBytes(plainSigningKey);
        var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(signingKey), SecurityAlgorithms.HmacSha256Signature);

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new System.Security.Claims.ClaimsIdentity(claims),
            Expires = expiration,
            SigningCredentials = signingCredentials
        };

        var token = jwtHandler.CreateToken(tokenDescriptor);
        return new JwtToken(token, expiration);
    }

    public Task<TIdentity?> ValidateJwt(string token)
    {
        return ValidateJwt(token, options.SigningKey);
    }

    private async Task<TIdentity?> ValidateJwt(
        string token,
        string plainSigningKey,
        CancellationToken cancellationToken = default)
    {
        var jwtHandler = new JsonWebTokenHandler();
        var signingKey = Encoding.ASCII.GetBytes(plainSigningKey);

        var validationResult = await jwtHandler.ValidateTokenAsync(token, new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(signingKey),
            ValidateIssuer = false,
            ValidateAudience = false
        });

        if (!validationResult.IsValid)
        {
            return null;
        }

        var identity = claimsIdentityMapping.ClaimsToIdentity(
            new Dictionary<string, string>(
                validationResult.Claims.Select(
                    item => new KeyValuePair<string, string>(item.Key, item.Value?.ToString() ?? "")
                )
            )
        );
        return identity;
    }
}

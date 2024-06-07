using System.Linq;
using System.Text;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace Commons.API.Auth.Authentication;

public class JwtAuthentication<TIdentity> where TIdentity : class
{
    private readonly IClaimsIdentityMapping<TIdentity> claimsIdentityMapping;
    public JwtAuthentication(IClaimsIdentityMapping<TIdentity> claimsIdentityMapping)
    {
        this.claimsIdentityMapping = claimsIdentityMapping;
    }

    public string GenerateJwt(
        TIdentity identity,
        string plainSigningKey,
        DateTime expiration)
    {
        var jwtHandler = new JsonWebTokenHandler();

        var claims = this.claimsIdentityMapping.IdentityToClaims(identity).Select(item => new System.Security.Claims.Claim(item.Key, item.Value));

        var signingKey = Encoding.ASCII.GetBytes(plainSigningKey);
        var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(signingKey), SecurityAlgorithms.HmacSha256Signature);

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new System.Security.Claims.ClaimsIdentity(claims),
            Expires = expiration
        };

        var jwtToken = jwtHandler.CreateToken(tokenDescriptor);
        return jwtToken;
    }

    public async Task<TIdentity?> ValidateJwt(
        string token,
        string plainSigningKey)
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

        var identity = this.claimsIdentityMapping.ClaimsToIdentity(
            new Dictionary<string, string>(
                validationResult.Claims.Select(
                    item => new KeyValuePair<string, string>(item.Key, item.Value?.ToString() ?? "")
                )
            )
        );
        return identity;
    }
}

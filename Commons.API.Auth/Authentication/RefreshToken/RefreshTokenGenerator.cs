using System.Security.Cryptography;
using Microsoft.Extensions.Options;

namespace Commons.API.Auth.Authentication.RefreshToken;

public class RefreshTokenGenerator
{
    private readonly RefreshTokenOptions options;
    public RefreshTokenGenerator(IOptions<RefreshTokenOptions> options)
    {
        this.options = options.Value;
    }

    public RefreshToken Generate()
    {
        var token = RandomNumberGenerator.GetHexString(options.Length, false);
        var issuedAt = DateTime.UtcNow;
        var expiration = DateTime.UtcNow + this.options.Lifespan;
        return new RefreshToken(token, issuedAt, expiration);
    }
}

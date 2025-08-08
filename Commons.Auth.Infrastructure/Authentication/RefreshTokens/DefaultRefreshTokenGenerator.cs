using System.Security.Cryptography;
using Commons.Auth.Application.Abstractions.Authentication.RefreshTokens;
using Microsoft.Extensions.Options;

namespace Commons.Auth.Infrastructure.Authentication.RefreshTokens;

public class DefaultRefreshTokenGenerator: IRefreshTokenGenerator
{
    private readonly RefreshTokenOptions options;
    public DefaultRefreshTokenGenerator(IOptions<RefreshTokenOptions> options)
    {
        this.options = options.Value;
    }

    public RefreshTokenDto Generate()
    {
        var token = RandomNumberGenerator.GetHexString(options.Length, false);
        var issuedAt = DateTime.UtcNow;
        var expiration = DateTime.UtcNow + options.Lifespan;
        return new RefreshTokenDto(token, issuedAt, expiration);
    }
}

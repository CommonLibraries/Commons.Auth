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

    public RefreshTokenDTO Generate()
    {
        var token = RandomNumberGenerator.GetHexString(options.Length, false);
        var issuedAt = DateTime.UtcNow;
        var expiration = DateTime.UtcNow + options.Lifespan;
        return new RefreshTokenDTO(token, issuedAt, expiration);
    }
}

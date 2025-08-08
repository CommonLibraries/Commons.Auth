namespace Commons.Auth.Application.Abstractions.Authentication.RefreshTokens;

public class RefreshTokenDto
{
    public string Token { get; }
    public DateTime IssuedAt { get; }
    public DateTime Expiration { get; }

    public RefreshTokenDto(string token, DateTime issuedAt, DateTime expiration)
    {
        Token = token;
        IssuedAt = issuedAt;
        Expiration = expiration;
    }
}

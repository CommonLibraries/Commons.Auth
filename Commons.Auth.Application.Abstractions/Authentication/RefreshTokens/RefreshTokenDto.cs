namespace Commons.Auth.Application.Abstractions.Authentication.RefreshTokens;

public class RefreshTokenDTO
{
    public string Token { get; }
    public DateTime IssuedAt { get; }
    public DateTime Expiration { get; }

    public RefreshTokenDTO(string token, DateTime issuedAt, DateTime expiration)
    {
        Token = token;
        IssuedAt = issuedAt;
        Expiration = expiration;
    }
}

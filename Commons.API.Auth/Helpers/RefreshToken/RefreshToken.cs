namespace Commons.API.Auth.Helpers.RefreshToken;

public class RefreshToken
{
    public string Token { get; }
    public DateTime IssuedAt { get; }
    public DateTime Expiration { get; }

    public RefreshToken(string token, DateTime issuedAt, DateTime expiration)
    {
        Token = token;
        IssuedAt = issuedAt;
        Expiration = expiration;
    }
}

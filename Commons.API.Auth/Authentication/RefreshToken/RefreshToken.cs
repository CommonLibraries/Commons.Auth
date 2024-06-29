namespace Commons.API.Auth.Authentication.RefreshToken;

public class RefreshToken
{
    public string Token { get; }
    public DateTime IssuedAt { get; }
    public DateTime Expiration { get; }

    public RefreshToken(string token, DateTime issuedAt, DateTime expiration)
    {
        this.Token = token;
        this.IssuedAt = issuedAt;
        this.Expiration = expiration;
    }
}

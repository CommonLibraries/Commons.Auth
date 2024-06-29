namespace Commons.API.Auth.Authentication.Jwt;

public class JwtToken
{
    public string Token { get; }
    public DateTime Expiration { get; }

    public JwtToken(string token, DateTime expiration)
    {
        this.Token = token;
        this.Expiration = expiration;
    }
}

namespace Commons.Auth.Application.Abstractions.Authentication.Jwt;

public class JwtToken
{
    public string Token { get; }
    public DateTime Expiration { get; }

    public JwtToken(string token, DateTime expiration)
    {
        Token = token;
        Expiration = expiration;
    }
}

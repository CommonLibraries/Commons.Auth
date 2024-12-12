namespace Commons.API.Auth.Authentication.Tokens.JWT;

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

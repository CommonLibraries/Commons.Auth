namespace Commons.Auth.Application.Abstractions.Authentication.AccessTokens;

public class AccessTokenDTO
{
    public string Token { get; }
    public DateTime Expiration { get; }

    public AccessTokenDTO(string token, DateTime expiration)
    {
        Token = token;
        Expiration = expiration;
    }
}

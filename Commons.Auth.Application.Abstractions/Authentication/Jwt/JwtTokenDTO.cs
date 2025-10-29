namespace Commons.Auth.Application.Abstractions.Authentication.Jwt;

public class JwtTokenDTO
{
    public string Token { get; }
    public DateTime Expiration { get; }

    public JwtTokenDTO(string token, DateTime expiration)
    {
        Token = token;
        Expiration = expiration;
    }
}

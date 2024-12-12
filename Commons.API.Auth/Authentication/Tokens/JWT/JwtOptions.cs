namespace Commons.API.Auth.Authentication.Tokens.JWT;

public class JwtOptions
{
    public string SigningKey { get; set; } = string.Empty;
    public TimeSpan Lifespan { get; set; } = TimeSpan.Zero;
}

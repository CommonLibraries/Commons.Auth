namespace Commons.API.Auth.Authentication;

public class JwtOptions
{
    public string SigningKey { get; set; } = string.Empty;
    public TimeSpan Lifespan { get; set; } = TimeSpan.Zero;
}

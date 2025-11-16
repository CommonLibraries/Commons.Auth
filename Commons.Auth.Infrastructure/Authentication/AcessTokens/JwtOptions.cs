namespace Commons.Auth.Infrastructure.Authentication.AccessTokens
{
    public class JwtOptions
    {
        public string SigningKey { get; set; } = string.Empty;
        public TimeSpan Lifespan { get; set; } = TimeSpan.Zero;
    }
}

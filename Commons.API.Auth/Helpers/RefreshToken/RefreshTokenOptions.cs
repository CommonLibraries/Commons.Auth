namespace Commons.API.Auth.Helpers.RefreshToken;

public class RefreshTokenOptions
{
    public TimeSpan Lifespan { get; set; } = TimeSpan.Zero;
    public int Length { get; set; } = 16;
}

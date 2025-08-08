namespace Commons.Auth.Application.Abstractions.Authentication.Jwt
{
    public interface IJwtValidator<TJwtPayload>
    {
        Task<TJwtPayload?> Validate(string token, CancellationToken cancellationToken = default);
    }
}

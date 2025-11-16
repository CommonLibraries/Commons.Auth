namespace Commons.Auth.Application.Abstractions.Authentication.AccessTokens
{
    public interface IAccessTokenValidator<TAccessTokenPayload>
    {
        Task<TAccessTokenPayload?> Validate(string token, CancellationToken cancellationToken = default);
    }
}

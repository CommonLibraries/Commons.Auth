namespace Commons.Auth.Application.Abstractions.Authentication.AccessTokens
{
    public interface IAccessTokenPayloadMapping<TAccessTokenPayload>
    {
        IDictionary<string, string> ToClaims(TAccessTokenPayload payload);
        TAccessTokenPayload FromClaims(IDictionary<string, string> claims);
    }
}

namespace Commons.Auth.Application.Abstractions.Authentication.Jwt
{
    public interface IJwtPayloadMapping<TJwtPayload>
    {
        IDictionary<string, string> ToClaims(TJwtPayload jwtPayload);
        TJwtPayload FromClaims(IDictionary<string, string> claims);
    }
}

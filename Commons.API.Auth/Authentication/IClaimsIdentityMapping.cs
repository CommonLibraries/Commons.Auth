namespace Commons.API.Auth.Authentication
{
    public interface IClaimsIdentityMapping<TIdentity>
    {
        TIdentity ClaimsToIdentity(IDictionary<string, string> claims);
        IDictionary<string, string> IdentityToClaims(TIdentity identity);
    }
}

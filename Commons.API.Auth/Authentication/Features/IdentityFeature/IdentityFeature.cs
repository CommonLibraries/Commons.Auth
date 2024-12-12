namespace Commons.API.Auth.Authentication.Features.AuthenticationFeature;

public class IdentityFeature<TIdentity> : IIdentityFeature<TIdentity> where TIdentity : class, new()
{
    private TIdentity identity;
    public IdentityFeature()
    {
        identity = new TIdentity();
    }

    public TIdentity Identity
    {
        get => identity;
        set => identity = value;
    }
}

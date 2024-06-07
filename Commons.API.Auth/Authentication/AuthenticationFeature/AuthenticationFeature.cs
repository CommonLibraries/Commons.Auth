namespace Commons.API.Auth.Authentication;

public class AuthenticationFeature<TIdentity> : IAuthenticationFeature<TIdentity> where TIdentity : class, new()
{
    private TIdentity identity;
    public AuthenticationFeature()
    {
        this.identity = new TIdentity();
    }

    public TIdentity Identity {
        get => this.identity;
        set => this.identity = value;
    }
}

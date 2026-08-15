namespace Commons.Auth.API.Authentication.Contexts.IdentityContext;

public class MutableIdentityContext<TIdentity> : IMutableIdentityContext<TIdentity>
{
    public TIdentity? Current { get; set; }
}

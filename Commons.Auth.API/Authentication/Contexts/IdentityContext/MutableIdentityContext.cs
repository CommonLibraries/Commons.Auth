namespace Commons.Auth.API.Authentication.Middlewares;

public class MutableIdentityContext<TIdentity> : IMutableIdentityContext<TIdentity>
{
    public TIdentity? Current { get; set; }
}

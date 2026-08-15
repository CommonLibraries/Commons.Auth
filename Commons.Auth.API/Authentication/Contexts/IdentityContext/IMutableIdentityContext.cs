namespace Commons.Auth.API.Authentication.Contexts.IdentityContext
{
    public interface IMutableIdentityContext<TIdentity> : IIdentityContext<TIdentity>
    {
        new TIdentity? Current { get; set; }
    }
}

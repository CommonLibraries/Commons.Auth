namespace Commons.Auth.API.Authentication.Contexts.IdentityContext;

public class NotNullableIdentityContext<TIdentity> : INotNullableIdentityContext<TIdentity>
{
    private readonly TIdentity? identity;
    public NotNullableIdentityContext(IIdentityContext<TIdentity> identityContext)
    {
        this.identity = identityContext.Current;
    }

    public TIdentity Current => identity ?? throw new InvalidOperationException("Identity context is null.");
}

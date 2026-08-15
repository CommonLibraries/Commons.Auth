namespace Commons.Auth.API.Authentication.Contexts.IdentityContext;

public interface IIdentityContext<TIdentity>
{
    TIdentity? Current { get; }
}

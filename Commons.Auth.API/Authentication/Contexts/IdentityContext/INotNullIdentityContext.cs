namespace Commons.Auth.API.Authentication.Contexts.IdentityContext;

public interface INotNullableIdentityContext<TIdentity> : IIdentityContext<TIdentity>
{
    new TIdentity Current { get; }
}

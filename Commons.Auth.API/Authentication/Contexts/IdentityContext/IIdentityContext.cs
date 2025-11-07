namespace Commons.Auth.API.Authentication.Contexts
{
    public interface IIdentityContext<TIdentity>
    {
        TIdentity Current { get; }
    }
}

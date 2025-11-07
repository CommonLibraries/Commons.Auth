using Commons.Auth.API.Authentication.Contexts;

namespace Commons.Auth.API.Authentication.Middlewares
{
    public interface IMutableIdentityContext<TIdentity> : IIdentityContext<TIdentity>
    {
        new TIdentity Current { get; set; }
    }
}

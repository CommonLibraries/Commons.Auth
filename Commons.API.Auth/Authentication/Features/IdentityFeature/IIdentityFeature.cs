namespace Commons.API.Auth.Authentication.Features.AuthenticationFeature;

public interface IIdentityFeature<TIdentity>
{
    public TIdentity Identity { get; set; }
}

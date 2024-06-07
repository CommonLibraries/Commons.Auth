namespace Commons.API.Auth.Authentication;

public interface IAuthenticationFeature<TIdentity>
{
    public TIdentity Identity { get; set; }
}

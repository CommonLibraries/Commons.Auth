namespace Commons.Auth.API.Authentication.Features.JwtPayloadFeature;

public interface IJwtPayloadFeature<TIdentity>
{
    public TIdentity Identity { get; set; }
}

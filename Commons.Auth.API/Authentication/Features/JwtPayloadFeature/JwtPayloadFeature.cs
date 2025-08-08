namespace Commons.Auth.API.Authentication.Features.JwtPayloadFeature;

public class JwtPayloadFeature<TJwtPayload> : IJwtPayloadFeature<TJwtPayload> where TJwtPayload : class, new()
{
    private TJwtPayload jwtPayload;
    public JwtPayloadFeature()
    {
        jwtPayload = new TJwtPayload();
    }

    public TJwtPayload Identity
    {
        get => jwtPayload;
        set => jwtPayload = value;
    }
}

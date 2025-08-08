namespace Commons.API.Auth.Authorization.Features.AuthorizationFeature;

public class AuthorizationFeature : IAuthorizationFeature
{
    public bool AllowBypassRestrictAccess { get; set; }
}

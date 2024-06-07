namespace Commons.API.Auth.Authorization;

public class AuthorizationFeature : IAuthorizationFeature
{
    public bool AllowBypassRestrictAccess { get; set; }
}

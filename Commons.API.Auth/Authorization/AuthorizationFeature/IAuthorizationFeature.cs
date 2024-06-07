namespace Commons.API.Auth.Authorization;

public interface IAuthorizationFeature
{
    bool AllowBypassRestrictAccess { get; set; }
}

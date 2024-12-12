namespace Commons.API.Auth.Authorization.Features.AuthorizationFeature;

public interface IAuthorizationFeature
{
    bool AllowBypassRestrictAccess { get; set; }
}

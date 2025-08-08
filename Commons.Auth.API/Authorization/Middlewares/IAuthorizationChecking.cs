namespace Commons.Auth.API.Authorization.Middlewares;

public interface IAuthorizationChecking<TIdentity> where TIdentity : class, new()
{
    Task<bool> Check(TIdentity identity, string permission, CancellationToken cancellationToken = default);
}

namespace Commons.API.Auth.Authorization;

public interface IAuthorizationChecking<TIdentity> where TIdentity : class, new()
{
    Task<bool> Check(TIdentity identity, string permission, CancellationToken cancellationToken = default);
}

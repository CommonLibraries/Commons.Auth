namespace Commons.Auth.Application.Abstractions.Authorizations;

public interface IAuthorizationChecking<TIdentity>
{
    Task<bool> Check(TIdentity identity, string permission, CancellationToken cancellationToken = default);
}

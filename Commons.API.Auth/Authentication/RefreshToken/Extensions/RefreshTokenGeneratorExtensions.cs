using Microsoft.Extensions.DependencyInjection;

namespace Commons.API.Auth.Authentication.RefreshToken.Extensions;

public static class RefreshTokenGeneratorExtensions
{
    public static IRefreshTokenGeneratorServiceBuilder SetupRefreshTokenGenerator(this IServiceCollection services)
    {
        return new DefaultRefreshTokenGeneratorServiceBuilder(services);
    }
}

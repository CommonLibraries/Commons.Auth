using Commons.Auth.Application.Abstractions.Authentication.RefreshTokens;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Commons.Auth.Infrastructure.Authentication.RefreshTokens.Extensions;

public static class RefreshTokenGeneratorExtensions
{
    public static IRefreshTokenGeneratorServiceBuilder AddRefreshTokenGenerator(this IServiceCollection services)
    {
        services.TryAddTransient<IRefreshTokenGenerator, DefaultRefreshTokenGenerator>();
        return new DefaultRefreshTokenGeneratorServiceBuilder(services);
    }
}

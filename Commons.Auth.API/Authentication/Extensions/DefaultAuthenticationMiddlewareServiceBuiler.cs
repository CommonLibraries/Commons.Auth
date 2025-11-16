using Commons.Auth.API.Authentication.Middlewares;
using Commons.Auth.Application.Abstractions.Authentication.AccessTokens;
using Commons.Auth.Infrastructure.Authentication.AccessTokens;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Collections;

namespace Commons.Auth.API.Authentication.Extensions;

internal class DefaultAuthenticationMiddlewareServiceBuiler<TJwtPayload> :
    IAuthenticationMiddlewareServiceBuiler<TJwtPayload>
{
    private readonly IServiceCollection services;
    public DefaultAuthenticationMiddlewareServiceBuiler(IServiceCollection services)
    {
        this.services = services;
    }
}

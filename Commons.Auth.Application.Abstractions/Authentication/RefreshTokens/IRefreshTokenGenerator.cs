using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Auth.Application.Abstractions.Authentication.RefreshTokens
{
    public interface IRefreshTokenGenerator
    {
        RefreshTokenDTO Generate();
    }
}

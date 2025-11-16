using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Auth.Application.Abstractions.Authentication.AccessTokens
{
    public interface IAccessTokenGenerator<TAccessTokenPayload>
    {
        AccessTokenDTO Generate(TAccessTokenPayload payload);
    }
}

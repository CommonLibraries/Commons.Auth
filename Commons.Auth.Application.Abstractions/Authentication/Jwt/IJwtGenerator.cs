using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Auth.Application.Abstractions.Authentication.Jwt
{
    public interface IJwtGenerator<TJwtPayload>
    {
        JwtTokenDTO GenerateToken(TJwtPayload payload);
    }
}

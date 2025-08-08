namespace Commons.Auth.API.Authentication.Features.JwtTokenFeature
{
    public class JwtTokenFeature : IJwtTokenFeature
    {
        public string Token { get; }

        public JwtTokenFeature(string token)
        {
            Token = token;
        }
    }
}

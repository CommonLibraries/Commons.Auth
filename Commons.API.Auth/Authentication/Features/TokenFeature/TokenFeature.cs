namespace Commons.API.Auth.Authentication.Features.RawAuthenticationFeature
{
    public class TokenFeature : ITokenFeature
    {
        public string AccessToken { get; }

        public TokenFeature(string accessToken)
        {
            AccessToken = accessToken;
        }
    }
}

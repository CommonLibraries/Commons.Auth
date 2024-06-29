namespace Commons.API.Auth.Authentication
{
    public class AuthenticationInputFeature : IAuthenticationInputFeature
    {
        public string AccessToken { get; }

        public AuthenticationInputFeature(string accessToken)
        {
            this.AccessToken = accessToken;
        }
    }
}

namespace Commons.Auth.API.Authentication.Contexts
{
    public class MutableAccessTokenContext : IMutableAccessTokenContext
    {
        public string Current { get; set; } = string.Empty; 
    }
}

namespace Commons.Auth.API.Authentication.Contexts
{
    public interface IMutableAccessTokenContext : IAccessTokenContext
    {
        new string Current { get; set; }
    }
}

namespace Commons.Auth.API.Authentication.Contexts
{
    public interface IMutableJwtTokenContext : IJwtTokenContext
    {
        new string Current { get; set; }
    }
}

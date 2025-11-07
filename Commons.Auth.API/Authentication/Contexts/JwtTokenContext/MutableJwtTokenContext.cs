namespace Commons.Auth.API.Authentication.Contexts
{
    public class MutableJwtTokenContext : IMutableJwtTokenContext
    {
        public string Current { get; set; } = string.Empty; 
    }
}

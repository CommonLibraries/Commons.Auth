namespace Commons.Auth.API.Authorization.Middlewares;
public class AuthorizeAttribute : Attribute
{
    public string Permission { get; protected set; }
    public AuthorizeAttribute(string permission)
    {
        Permission = permission;
    }
}

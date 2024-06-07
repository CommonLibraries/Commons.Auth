namespace Commons.API.Auth.Authorization;
public class AuthorizeAttribute : Attribute
{
    public string Permission { get; protected set; }
    public AuthorizeAttribute(string permission)
    {
        this.Permission = permission;
    }
}

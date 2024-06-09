namespace Commons.API.Auth.Authentication
{
    public interface IIdentityValidation<TIdentity>                                                     
    {
        bool Validate(TIdentity identity);
    }
}

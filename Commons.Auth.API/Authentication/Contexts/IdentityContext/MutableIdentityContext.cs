namespace Commons.Auth.API.Authentication.Middlewares
{
    public class MutableIdentityContext<TIdentity> : IMutableIdentityContext<TIdentity>
    {
        private TIdentity? identity;
        public TIdentity Current
        {
            get => this.identity ?? throw new ArgumentNullException(nameof(this.identity));
            set => this.identity = value;
        }
    }
}

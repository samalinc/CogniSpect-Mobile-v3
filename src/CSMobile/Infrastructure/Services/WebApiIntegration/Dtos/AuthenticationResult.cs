namespace CSMobile.Infrastructure.Services.WebApiIntegration.Dtos
{
    public class AuthenticationResult
    {
        public string AuthToken { get; set; }

        public AccountDto Account { get; set; }
    }
}
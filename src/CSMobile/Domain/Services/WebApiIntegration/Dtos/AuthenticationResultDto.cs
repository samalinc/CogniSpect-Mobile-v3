namespace CSMobile.Domain.Services.WebApiIntegration.Dtos
{
    public class AuthenticationResultDto
    {
        public string AuthToken { get; set; }

        public AccountDto Account { get; set; }
    }
}
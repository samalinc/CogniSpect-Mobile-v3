namespace CSMobile.Infrastructure.Services.WebApiIntegration.Authentication
{
    public class AuthenticationResponseData
    {
        public AuthenticationResponseData(bool succeeded, string token)
        {
            Succeeded = succeeded;
            Token = token;
        }

        public bool Succeeded { get; set; }

        public string Token { get; set; }
    }
}
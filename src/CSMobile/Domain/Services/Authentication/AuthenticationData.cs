namespace CSMobile.Domain.Services.Authentication
{
    public class AuthenticationData
    {
        public AuthenticationData(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public string Login { get; set; }

        public string Password { get; set; }
    }
}
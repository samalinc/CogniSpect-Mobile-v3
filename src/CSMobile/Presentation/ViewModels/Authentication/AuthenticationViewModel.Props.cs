namespace CSMobile.Presentation.ViewModels.Authentication
{
    public partial class AuthenticationViewModel
    {
        public bool IsFirstStart { get; set; } = true;
        
        private string _login;
        private string _password;
        private bool _rememberMe;
        
        public string Login
        {
            get => _login;
            set => Set(nameof(Login), ref _login, value);
        }
        
        public string Password
        {
            get => _password;
            set => Set(nameof(Password), ref _password, value);
        }
        
        public bool RememberMe
        {
            get => _rememberMe;
            set => Set(nameof(RememberMe), ref _rememberMe, value);
        }
    }
}
namespace CSMobile.Application.ViewModels.ViewModels.Authentication
{
    public partial class AuthenticationViewModel
    {
        private string _studNumber;
        private string _password;
        
        public string StudNumber
        {
            get => _studNumber;
            set => Set(nameof(StudNumber), ref _studNumber, value);
        }
        
        public string Password
        {
            get => _password;
            set => Set(nameof(Password), ref _password, value);
        }
    }
}
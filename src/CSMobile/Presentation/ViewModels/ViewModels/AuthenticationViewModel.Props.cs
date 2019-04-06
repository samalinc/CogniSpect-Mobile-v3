namespace CSMobile.Application.ViewModels.ViewModels
{
    public partial class AuthenticationViewModel
    {
        private string _studNumber;
        private bool _isThinking;
        private string _password;
        
        public bool IsThinking
        {
            get => _isThinking;
            set => Set(nameof(IsThinking), ref _isThinking, value);
        }
        
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
namespace CSMobile.Application.ViewModels.ViewModels
{
    public abstract partial class BasePageViewModel
    {
        private bool _isThinking;
        
        public bool IsThinking
        {
            get => _isThinking;
            set => Set(nameof(IsThinking), ref _isThinking, value);
        }

        public virtual string Title { get; set; }
    }
}
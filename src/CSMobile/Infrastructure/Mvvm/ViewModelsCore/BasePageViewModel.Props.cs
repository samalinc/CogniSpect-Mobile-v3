namespace CSMobile.Infrastructure.Mvvm.ViewModelsCore
{
    public abstract partial class BasePageViewModel
    {
        private bool _isBusy;
        
        public bool IsBusy
        {
            get => _isBusy;
            set => Set(nameof(IsBusy), ref _isBusy, value);
        }
    }
}
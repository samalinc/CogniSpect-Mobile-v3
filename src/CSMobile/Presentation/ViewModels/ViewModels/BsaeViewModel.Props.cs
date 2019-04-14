using System.Collections.ObjectModel;

namespace CSMobile.Application.ViewModels.ViewModels
{
    public abstract partial class BaseViewModel
    {
        private ObservableCollection<string> _exceptions;
        
        public ObservableCollection<string> Exceptions
        {
            get => _exceptions;
            set => Set(nameof(Exceptions), ref _exceptions, value);
        }
    }
}
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CSMobile.Presentation.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged , IViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

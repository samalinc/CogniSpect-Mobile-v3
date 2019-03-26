using System.Threading.Tasks;
using System.Windows.Input;
using CSMobile.Application.ViewModels.Services.Navigation;
using CSMobile.Application.ViewModels.Tests;
using GalaSoft.MvvmLight;
using Xamarin.Forms;

namespace CSMobile.Application.ViewModels.Profile
{
    public class ProfileViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public ICommand OpenTestsCommand { get; }

        public ProfileViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            OpenTestsCommand = new Command(async () => await OpenTests());
        }

        private async Task OpenTests()
        {
            await _navigationService.NavigateAsync<TestsViewModel>();
        }
    }
}
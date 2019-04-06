using System.Threading.Tasks;
using System.Windows.Input;
using CSMobile.Application.ViewModels.Navigation;
using CSMobile.Application.ViewModels.ViewModels.Tests;
using CSMobile.Application.ViewModels.ViewModels.Tests.List;
using Xamarin.Forms;

namespace CSMobile.Application.ViewModels.ViewModels
{
    public class ProfileViewModel : BasePageViewModel
    {
        private readonly INavigationService _navigationService;

        public ICommand OpenTestsCommand { get; }

        public ProfileViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService; 
            OpenTestsCommand = Command(OpenTests);
        }

        private async Task OpenTests()
        {
            await _navigationService.NavigateAsync<TestItemsViewModel>();
        }
    }
}
using System.Threading.Tasks;
using System.Windows.Input;
using CSMobile.Application.ViewModels.Navigation;
using CSMobile.Application.ViewModels.ViewModels.Tests.List;

namespace CSMobile.Application.ViewModels.ViewModels
{
    public class ProfileViewModel : BasePageViewModel
    {
        private readonly INavigationService _navigationService;

        public ICommand OpenTestsCommand { get; }
        public ICommand OpenStatisticCommand { get; }

        public ProfileViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            
            OpenTestsCommand = Command(OpenTests);
            OpenStatisticCommand = Command(OpenStatistic);
        }

        private async Task OpenTests()
        {
            await _navigationService.NavigateAsync<TestItemsViewModel>();
        }
        
        private async Task OpenStatistic()
        {
            await _navigationService.NavigateAsync<StatisticsViewModel>();
        }
    }
}
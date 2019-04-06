using System;
using System.Threading.Tasks;
using System.Windows.Input;
using CSMobile.Application.ViewModels.Navigation;
using CSMobile.Domain.Models.Tests;
using CSMobile.Domain.Services.Tests;
using GalaSoft.MvvmLight.Messaging;

namespace CSMobile.Application.ViewModels.ViewModels.Tests.List
{
    public class TestListItemViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly ITestsService _testsService;
        
        public ICommand OnTestStartedCommand { get; }
        
        public string Name { get; set; }
        
        public Guid Id { get; set; }
        
        public TestListItemViewModel(
            INavigationService navigationService,
            ITestsService testsService)
        {
            _navigationService = navigationService;
            _testsService = testsService;

            OnTestStartedCommand = Command(OnTestStarted);
        }
        
        private async Task OnTestStarted()
        {
            Test test = await _testsService.BeginTest(Id);
            await _navigationService.NavigateAsync<TestViewModel>();
            MessengerInstance.Send(new NotificationMessage<Test>(test, string.Empty));
        }
    }
}
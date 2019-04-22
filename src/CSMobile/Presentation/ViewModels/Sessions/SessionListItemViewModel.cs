using System.Threading.Tasks;
using System.Windows.Input;
using AutoMapper;
using CSMobile.Domain.Models.Sessions;
using CSMobile.Domain.Models.Tests;
using CSMobile.Domain.Services.Sessions;
using CSMobile.Infrastructure.Mvvm.Navigation;
using CSMobile.Infrastructure.Mvvm.ViewModelsCore;
using CSMobile.Presentation.ViewModels.Tests;
using GalaSoft.MvvmLight.Messaging;

namespace CSMobile.Presentation.ViewModels.Sessions
{
    public partial class SessionListItemViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly ISessionService _sessionService;
        private readonly IMapper _mapper;

        public ICommand OnTestStartedCommand { get; }
        
        public SessionListItemViewModel(
            INavigationService navigationService,
            ISessionService sessionService,
            IMapper mapper)
        {
            _navigationService = navigationService;
            _sessionService = sessionService;
            _mapper = mapper;

            OnTestStartedCommand = Command(OnTestStarted);
        }
        
        private async Task OnTestStarted()
        {
            Test test = await _sessionService.BeginSession(_mapper.Map<SessionListItem>(this));
            await _navigationService.NavigateAsync<TestViewModel>();
            MessengerInstance.Send(new NotificationMessage<Test>(test, string.Empty));
        }
    }
}
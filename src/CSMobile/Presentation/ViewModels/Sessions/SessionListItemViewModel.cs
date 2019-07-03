using System.Threading.Tasks;
using System.Windows.Input;
using AutoMapper;
using CSMobile.Domain.Models.Sessions;
using CSMobile.Domain.Models.Tests;
using CSMobile.Domain.Services.Sessions;
using CSMobile.Infrastructure.Mvvm.Navigation;
using CSMobile.Infrastructure.Mvvm.ViewModelsCore;
using CSMobile.Presentation.ViewModels.Permissions;
using CSMobile.Presentation.ViewModels.Tests;
using JetBrains.Annotations;

namespace CSMobile.Presentation.ViewModels.Sessions
{
    [UsedImplicitly]
    public partial class SessionListItemViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly ISessionService _sessionService;
        private readonly IMapper _mapper;
        private readonly IPermissionService _permissionService;

        public ICommand OnTestStartedCommand { get; }
        
        public SessionListItemViewModel(
            BasePageViewModel rootPageViewModel,
            INavigationService navigationService,
            ISessionService sessionService,
            IMapper mapper, IPermissionService permissionService)
        {
            _navigationService = navigationService;
            _sessionService = sessionService;
            _mapper = mapper;
            _permissionService = permissionService;

            OnTestStartedCommand = Command(OnTestStarted, rootPageViewModel);
        }
        
        private async Task OnTestStarted()
        {
            await _permissionService.RequestPermissionsIfNeeded(PhonePermission.Location);
            Test test = await _sessionService.BeginSession(_mapper.Map<SessionListItem>(this));
            await _navigationService.Navigate<TestViewModel, Test>(test);
        }
    }
}
using System.Threading.Tasks;
using System.Windows.Input;
using AutoMapper;
using CSMobile.Domain.Services.Authentication;
using CSMobile.Infrastructure.Mvvm.ViewModelsCore;
using JetBrains.Annotations;

namespace CSMobile.Presentation.ViewModels.Authentication
{
    [UsedImplicitly]
    public partial class AuthenticationViewModel : BasePageViewModel
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IAuthenticationAlertsFactory _authenticationAlertsFactory;
        private readonly IMapper _mapper;

        public ICommand AuthenticateCommand { get; }
        public ICommand RememberMeCommand { get; }

        public AuthenticationViewModel(
            IAuthenticationService authenticationService,
            IAuthenticationAlertsFactory authenticationAlertsFactory,
            IMapper mapper)
        {
            _authenticationService = authenticationService;
            _authenticationAlertsFactory = authenticationAlertsFactory;
            _mapper = mapper;

            AuthenticateCommand = Command(Authenticate, this);
            RememberMeCommand = Command(_authenticationService.ProcessRememberMe, this);
        }

        public override Task OnAppearing()
        {
            RememberMeCommand.Execute(null);
            return Task.CompletedTask;
        }

        private async Task Authenticate()
        {
            AuthenticationData data = _mapper.Map<AuthenticationData>(this);
            bool result = await _authenticationService.SignIn(data);

            if (!result)
            {
                await _authenticationAlertsFactory.IncorrectLoginOrPassword();
                return;
            }

            await _authenticationService.SafeDataForRememberMe(data, RememberMe);
        }
    }
}
using System.Threading.Tasks;
using System.Windows.Input;
using AutoMapper;
using CSMobile.Domain.Services.Authentication;
using CSMobile.Domain.Services.WebApiIntegration.Dtos;
using CSMobile.Infrastructure.Common;
using CSMobile.Infrastructure.Mvvm.LoadingDialog;
using CSMobile.Infrastructure.Mvvm.ViewModelsCore;

namespace CSMobile.Presentation.ViewModels.Authentication
{
    public partial class AuthenticationViewModel : BasePageViewModel
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IAuthenticationAlertsFactory _authenticationAlertsFactory;
        private readonly ILoadingFactory _loadingFactory;
        private readonly IUserContextService _userContextService;
        private readonly IMapper _mapper;

        public ICommand AuthenticateCommand { get; }

        public AuthenticationViewModel(
            IAuthenticationService authenticationService,
            IAuthenticationAlertsFactory authenticationAlertsFactory,
            ILoadingFactory loadingFactory,
            IUserContextService userContextService,
            IMapper mapper)
        {
            _authenticationService = authenticationService;
            _authenticationAlertsFactory = authenticationAlertsFactory;
            _loadingFactory = loadingFactory;
            _userContextService = userContextService;
            _mapper = mapper;

            AuthenticateCommand = Command(Authenticate);
        }

        public override Task OnAppearing()
        {
            StudNumber = null;
            Password = null;
            return Task.CompletedTask;
        }

        private async Task Authenticate()
        {
            AuthenticationResult result;
            using (await Loading.Start())
            {
                result = await _authenticationService.SignIn(new AuthenticationData(StudNumber, Password));
            }

            if (result == null)
            {
                await _authenticationAlertsFactory.IncorrectLoginOrPassword();
                return;
            }

            await _userContextService.BeginUserSession(_mapper.Map<UserContextData>(result));
        }
    }
}
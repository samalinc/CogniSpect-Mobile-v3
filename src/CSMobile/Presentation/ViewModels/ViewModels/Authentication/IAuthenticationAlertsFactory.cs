using System.Threading.Tasks;

namespace CSMobile.Application.ViewModels.ViewModels.Authentication
{
    public interface IAuthenticationAlertsFactory
    {
        Task IncorrectLoginOrPassword();
    }
}
using System.Threading.Tasks;

namespace CSMobile.Presentation.ViewModels.ViewModels.Authentication
{
    public interface IAuthenticationAlertsFactory
    {
        Task IncorrectLoginOrPassword();
    }
}
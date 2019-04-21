using System.Threading.Tasks;

namespace CSMobile.Presentation.ViewModels.Authentication
{
    public interface IAuthenticationAlertsFactory
    {
        Task IncorrectLoginOrPassword();
    }
}
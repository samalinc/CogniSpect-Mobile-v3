using System.Threading.Tasks;

namespace CSMobile.Presentation.ViewModels.Permissions
{
    public interface IPermissionService
    {
        Task RequestPermissionsIfNeeded(params PhonePermission[] permissions);
    }
}
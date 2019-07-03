using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSMobile.Presentation.ViewModels.Permissions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

namespace CSMobile.Presentation.Views.Services
{
    internal class PermissionService : IPermissionService
    {
        private static readonly IReadOnlyDictionary<PhonePermission, Permission> PermissionsMap =
            new Dictionary<PhonePermission, Permission>
            {
                {PhonePermission.Location, Permission.Location}
            };

        public async Task RequestPermissionsIfNeeded(params PhonePermission[] permissions)
        {
            await CrossPermissions.Current.RequestPermissionsAsync(permissions
                .Select(p => PermissionsMap[p])
                .ToArray());
        }
    }
}
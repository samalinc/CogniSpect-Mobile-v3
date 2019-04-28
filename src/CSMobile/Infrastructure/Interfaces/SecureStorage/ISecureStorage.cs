using System.Threading.Tasks;
using JetBrains.Annotations;

namespace CSMobile.Infrastructure.Interfaces.SecureStorage
{
    public interface ISecureStorage
    {
        Task InsertOrUpdate([NotNull] string key, [NotNull] string value);

        [ItemCanBeNull]
        Task<string> Get([NotNull] string key);

        Task ClearStorage();
        Task Remove([NotNull] string key);
    }
}
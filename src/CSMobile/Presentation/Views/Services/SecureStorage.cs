using System.Threading.Tasks;
using CSMobile.Infrastructure.Interfaces.SecureStorage;
using JetBrains.Annotations;
using XamarinSecureStorage = Xamarin.Essentials.SecureStorage;

namespace CSMobile.Presentation.Views.Services
{
    [UsedImplicitly]
    internal class SecureStorage : ISecureStorage
    {
        public async Task InsertOrUpdate(string key, string value)
        {
            await XamarinSecureStorage.SetAsync(key, value);
        }

        public async Task<string> Get(string key)
        {
            return await XamarinSecureStorage.GetAsync(key);
        }

        public Task ClearStorage()
        {
            XamarinSecureStorage.RemoveAll();
            return Task.CompletedTask;
        }

        public Task Remove(string key)
        {
            XamarinSecureStorage.Remove(key);
            return Task.CompletedTask;
        }
    }
}
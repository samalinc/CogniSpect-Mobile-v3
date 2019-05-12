using System.Threading.Tasks;
using CSMobile.Infrastructure.Security;
using JetBrains.Annotations;

namespace CSMobile.Domain.Services.Mfa
{
    [UsedImplicitly]
    internal class MfaService : IMfaService
    {
        private readonly IWifiPositionsService _wifiPositionsService;

        public MfaService(IWifiPositionsService wifiPositionsService)
        {
            _wifiPositionsService = wifiPositionsService;
        }

        public async Task<bool> IsSecondFactorPresented(SecondFactorVerificationData verificationData)
        {
            return await _wifiPositionsService.IsPositionOk(verificationData.SecurityPoints);
        }
    }
}
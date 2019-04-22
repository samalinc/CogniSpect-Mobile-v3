using System.Threading.Tasks;
using CSMobile.Infrastructure.Security;

namespace CSMobile.Domain.Services.Mfa
{
    internal class MfaService : IMfaService
    {
        private readonly IWifiPositionsService _wifiPositionsService;

        public MfaService(IWifiPositionsService wifiPositionsService)
        {
            _wifiPositionsService = wifiPositionsService;
        }

        public Task<bool> IsSecondFactorPresented(SecondFactorVerificationData verificationData)
        {
            return Task.FromResult(_wifiPositionsService.IsPositionOk(verificationData.SecurityPoints));
        }
    }
}
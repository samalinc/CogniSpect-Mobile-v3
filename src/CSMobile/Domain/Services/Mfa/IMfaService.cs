using System.Threading.Tasks;
using JetBrains.Annotations;

namespace CSMobile.Domain.Services.Mfa
{
    public interface IMfaService
    {
        Task<bool> IsSecondFactorPresented([NotNull] SecondFactorVerificationData verificationData);
    }
}
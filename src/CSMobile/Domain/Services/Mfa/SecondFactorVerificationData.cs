using System.Collections.Generic;

namespace CSMobile.Domain.Services.Mfa
{
    public class SecondFactorVerificationData
    {
        public IEnumerable<string> SecurityPoints { get; set; }
    }
}
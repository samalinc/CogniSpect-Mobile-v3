using System.Collections.Generic;

namespace CSMobile.Infrastructure.Common.Contexts.UserSession
{
    public interface IHaveUserContextData
    {
        Dictionary<string, object> ToData();
    }
}
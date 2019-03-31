using System.Collections.Generic;

namespace CSMobile.Infrastructure.Common.Contexts.Session
{
    public interface IHaveUserContextData
    {
        Dictionary<string, object> ToData();
    }
}
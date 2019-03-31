using System.Collections.Generic;
using CSMobile.Infrastructure.Common.Contexts.Session;

namespace CSMobile.Domain.Services.Authentication
{
    public class UserContextData : IHaveUserContextData
    {
        public string Login { get; set; }

        public Dictionary<string, object> ToData()
        {
            return new Dictionary<string, object>
            {
                {nameof(Login), Login}
            };
        }
    }
}
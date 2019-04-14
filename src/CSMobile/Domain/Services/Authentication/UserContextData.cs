using System.Collections.Generic;
using CSMobile.Infrastructure.Common.Contexts.UserSession;

namespace CSMobile.Domain.Services.Authentication
{
    public class UserContextData : IHaveUserContextData
    {
        public string Login { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }

        public Dictionary<string, object> ToData()
        {
            return new Dictionary<string, object>
            {
                {nameof(Login), Login},
                {nameof(Email), Email},
                {nameof(Token), Token}
            };
        }
    }
}
using System.Diagnostics;
using System.Threading.Tasks;
using CSMobile.Domain.Models.Sessions;
using CSMobile.Domain.Services.SharedEvents;
using CSMobile.Domain.Services.Tests;
using CSMobile.Infrastructure.WebSockets.ResponseHandling.Core;

namespace CSMobile.Presentation.ViewModels.Services
{
    public class WebSocketsHandlersRecorder : ResponseHandlersRecorder
    {
        public WebSocketsHandlersRecorder()
        {
#if DEBUG
            Register<SessionListItem>(ExternalEvents.NewMessage, arg =>
            {
                Debug.WriteLine("Test websockets handler:");
                Debug.WriteLine(ExternalEvents.NewMessage);
                return Task.CompletedTask;
            });
#endif
        }
    }
}
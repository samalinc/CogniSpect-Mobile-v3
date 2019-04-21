using System;
using System.Diagnostics;
using System.Threading.Tasks;
using CSMobile.Infrastructure.Interfaces.Exceptions;
using CSMobile.Infrastructure.Mvvm;
using CSMobile.Presentation.ViewModels.Services.Alerts;

namespace CSMobile.Presentation.ViewModels.Services.ExceptionHandling
{
    internal class AppExceptionHandler : IAppExceptionHandler
    {
        private readonly IAlertService _alertService;

        public AppExceptionHandler(IAlertService alertService)
        {
            _alertService = alertService;
        }

        public async Task HandleException(Exception ex)
        {
            Debug.WriteLine(ex.ToString());
            await _alertService.ErrorAlert(ResolveExceptionMessage(ex));
        }

        private string ResolveExceptionMessage(Exception ex)
        {
            switch (ex)
            {
                case WebSocketConnectionException _:
                    return "Connection error";
                case HttpConnectionException _:
                    return "Connection error";
                default:
                    return "An unexpected error has happened";
            }
        }
    }
}
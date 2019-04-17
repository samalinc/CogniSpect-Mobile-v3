using System;
using System.Threading.Tasks;
using CSMobile.Application.ViewModels.Alerts;
using CSMobile.Infrastructure.Services.Exceptions;

namespace CSMobile.Application.ViewModels.ExceptionHandling
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
            await _alertService.DisplayAlert("Error", ResolveExceptionMessage(ex), "Ok");
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
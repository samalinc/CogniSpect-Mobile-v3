using System;
using System.Diagnostics;
using System.Threading.Tasks;
using CSMobile.Domain.Services.Exceptions;
using CSMobile.Infrastructure.Interfaces.Exceptions;
using CSMobile.Infrastructure.Interfaces.Localization;
using CSMobile.Infrastructure.Mvvm;
using CSMobile.Presentation.ViewModels.Services.Dialogs.Alerts;
using JetBrains.Annotations;

namespace CSMobile.Presentation.ViewModels.Services.ExceptionHandling
{
    [UsedImplicitly]
    internal class AppExceptionHandler : IAppExceptionHandler
    {
        private readonly IAlertService _alertService;
        private readonly ILocalizer _localizer;

        public AppExceptionHandler(
            IAlertService alertService,
            ILocalizer localizer)
        {
            _alertService = alertService;
            _localizer = localizer;
        }

        public async Task HandleException(Exception ex)
        {
            await _alertService.ErrorAlert(ResolveExceptionMessage(ex));
        }

        private string ResolveExceptionMessage(Exception ex)
        {
            Debug.WriteLine(ex.ToString());
            switch (ex)
            {
                case WebSocketConnectionException _:
                case HttpConnectionException _:
                    return _localizer["ConnectionErrorMessage"];
                case InvalidStudentLocation _:
                    return _localizer["InvalidStudentLocationMessage"];
                default:
                    return _localizer["UnexpectedErrorMessage"];
            }
        }
    }
}
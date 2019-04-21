using Autofac;
using CSMobile.Infrastructure.Common.Extensions;
using CSMobile.Presentation.ViewModels.Authentication;
using CSMobile.Presentation.ViewModels.Core;
using CSMobile.Presentation.ViewModels.Profile;
using CSMobile.Presentation.ViewModels.Services;
using CSMobile.Presentation.ViewModels.Services.ExceptionHandling;
using CSMobile.Presentation.ViewModels.Sessions;
using CSMobile.Presentation.ViewModels.Statistics;
using CSMobile.Presentation.ViewModels.Tests;

namespace CSMobile.Presentation.ViewModels
{
    public class PresentationViewModelsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterScopedAsSelf<AuthenticationViewModel>()
                .RegisterScopedAsSelf<ProfileViewModel>()
                .RegisterScopedAsSelf<SessionItemsViewModel>()
                .RegisterScopedAsSelf<TestViewModel>()
                .RegisterScopedAsSelf<StatisticsViewModel>()
                .RegisterScopedAsSelf<TabbedLayoutViewModel>()
                .RegisterPerDependencyAsSelf<SessionListItemViewModel>()
                .RegisterPerDependencyAsSelf<QuestionViewModel>()
                .RegisterPerDependencyAsSelf<AnswerViewModel>();

            builder
                .RegisterSingleAsSelf<WebSocketsHandlersRecorder>()
                .RegisterSingleAsImplementedInterfaces<AppExceptionHandler>()
                .RegisterSingleAsImplementedInterfaces<AuthenticationAlertsFactory>();
        }
    }
}
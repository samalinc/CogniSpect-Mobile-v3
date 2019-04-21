using Autofac;
using CSMobile.Infrastructure.Common.Extensions;
using CSMobile.Presentation.ViewModels.ExceptionHandling;
using CSMobile.Presentation.ViewModels.ViewModels.Authentication;
using CSMobile.Presentation.ViewModels.ViewModels.Core;
using CSMobile.Presentation.ViewModels.ViewModels.Profile;
using CSMobile.Presentation.ViewModels.ViewModels.Statistics;
using CSMobile.Presentation.ViewModels.ViewModels.Tests;
using CSMobile.Presentation.ViewModels.ViewModels.Tests.List;

namespace CSMobile.Presentation.ViewModels
{
    public class PresentationViewModelsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterScopedAsSelf<AuthenticationViewModel>()
                .RegisterScopedAsSelf<ProfileViewModel>()
                .RegisterScopedAsSelf<TestItemsViewModel>()
                .RegisterScopedAsSelf<TestViewModel>()
                .RegisterScopedAsSelf<StatisticsViewModel>()
                .RegisterScopedAsSelf<TabbedLayoutViewModel>()
                .RegisterPerDependencyAsSelf<TestListItemViewModel>()
                .RegisterPerDependencyAsSelf<QuestionViewModel>()
                .RegisterPerDependencyAsSelf<AnswerViewModel>();

            builder
                .RegisterSingleAsSelf<WebSocketsHandlersRecorder>()
                .RegisterSingleAsImplementedInterfaces<AppExceptionHandler>()
                .RegisterSingleAsImplementedInterfaces<AuthenticationAlertsFactory>();
        }
    }
}
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
using CSMobile.Presentation.ViewModels.Tests.Questions;
using CSMobile.Presentation.ViewModels.Tests.Questions.Answers;

namespace CSMobile.Presentation.ViewModels
{
    public class PresentationViewModelsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .ScopedAsSelf<AuthenticationViewModel>()
                .ScopedAsSelf<ProfileViewModel>()
                .ScopedAsSelf<SessionItemsViewModel>()
                .ScopedAsSelf<TestViewModel>()
                .ScopedAsSelf<StatisticsViewModel>()
                .ScopedAsSelf<TabbedLayoutViewModel>()
                .PerDependencyAsSelf<SessionListItemViewModel>()
                .PerDependencyAsSelf<QuestionViewModel>()
                .PerDependencyAsSelf<AnswerViewModel>();

            builder
                .SingleAsSelf<WebSocketsHandlersRecorder>()
                .SingleAsImplementedInterfaces<AppExceptionHandler>()
                .SingleAsImplementedInterfaces<AuthenticationAlertsFactory>();
        }
    }
}
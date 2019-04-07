using Autofac;
using CSMobile.Application.ViewModels.ViewModels;
using CSMobile.Application.ViewModels.ViewModels.Tests;
using CSMobile.Application.ViewModels.ViewModels.Tests.List;
using CSMobile.Infrastructure.Common.Extensions;

namespace CSMobile.Application.ViewModels
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
                .RegisterPerDependencyAsSelf<TestListItemViewModel>()
                .RegisterPerDependencyAsSelf<QuestionViewModel>()
                .RegisterPerDependencyAsSelf<AnswerViewModel>();
        }
    }
}
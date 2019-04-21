using Autofac;
using CSMobile.Domain.Services.Authentication;
using CSMobile.Domain.Services.Tests;
using CSMobile.Domain.Services.WebApiIntegration;
using CSMobile.Infrastructure.Common.Extensions;

namespace CSMobile.Domain.Services
{
    public class DomainServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterScopedAsImplementedInterfaces<TestsService>()
                .RegisterScopedAsImplementedInterfaces<AuthenticationService>()
                .RegisterScopedAsImplementedInterfaces<QuestionsService>()
                .RegisterScopedAsImplementedInterfaces<CsApiClient>();
        }
    }
}
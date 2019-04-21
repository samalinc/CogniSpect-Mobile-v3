using Autofac;
using CSMobile.Domain.Services.Authentication;
using CSMobile.Domain.Services.Sessions;
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
                .RegisterSingleAsImplementedInterfaces<TestsService>()
                .RegisterSingleAsImplementedInterfaces<AuthenticationService>()
                .RegisterSingleAsImplementedInterfaces<QuestionsService>()
                .RegisterSingleAsImplementedInterfaces<CsApiClient>()
                .RegisterSingleAsImplementedInterfaces<SessionService>();
        }
    }
}
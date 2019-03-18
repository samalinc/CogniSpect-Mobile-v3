using Autofac;
using CSMobile.Application.Common;
using CSMobile.Domain.Services;
using CSMobile.Infrastructure.Services;
using CSMobile.Presentation.ViewModels;
using CSMobile.Presentation.Views.AppContext;
using CSMobile.Presentation.Views.Extensions;

namespace CSMobile.Presentation.Views
{
    public class Application
    {
        public static IApplicationContext AppContext { get; private set; }
        
        public void Configure()
        {
            AppContext = new ApplicationContextBuilder()
                .AddAutofacContainer(builder =>
                {
                    builder
                        .RegisterModule<ApplicationCommonModule>()
                        .RegisterModule<PresentationViewsModule>()
                        .RegisterModule<ApplicationViewModelsModule>()
                        .RegisterModule<DomainServicesModule>()
                        .RegisterModule<InfrastructureServicesModule>();
                })
                .Build();
        }
    }
}
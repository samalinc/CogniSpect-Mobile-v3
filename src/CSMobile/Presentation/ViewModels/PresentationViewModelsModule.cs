using Autofac;
using CSMobile.Application.ViewModels.Authentication;
using CSMobile.Application.ViewModels.Profile;
using CSMobile.Infrastructure.Common.Extensions;

namespace CSMobile.Application.ViewModels
{
    public class PresentationViewModelsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                .AsSelf()
                .InstancePerLifetimeScope();
        }
    }
}
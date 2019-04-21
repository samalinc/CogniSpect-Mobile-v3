using Autofac;
using CSMobile.Infrastructure.Common.Extensions;

namespace CSMobile.Infrastructure.Mvvm
{
    public class MvvmModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterSingleAsImplementedInterfaces<ViewModelsFactory>();
        }
    }
}
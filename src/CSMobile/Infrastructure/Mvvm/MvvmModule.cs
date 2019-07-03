using Autofac;
using CSMobile.Infrastructure.Common.Extensions;
using CSMobile.Infrastructure.Mvvm.Commands;

namespace CSMobile.Infrastructure.Mvvm
{
    public class MvvmModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .SingleAsImplementedInterfaces<ViewModelsFactory>()
                .SingleAsImplementedInterfaces<CommandsFactory>();
        }
    }
}
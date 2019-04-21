using Autofac;
using CSMobile.Infrastructure.Common.Extensions;

namespace CSMobile.Presentation.Droid
{
    internal class AndroidModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterSingleAsImplementedInterfaces<AndroidWifiPositionsService>()
                .RegisterSingleAsImplementedInterfaces<AndroidCultureResolver>();
        }
    }
}
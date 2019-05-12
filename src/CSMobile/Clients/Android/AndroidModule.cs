using Android.Content;
using Autofac;
using CSMobile.Infrastructure.Common.Extensions;
using CSMobile.Presentation.Droid.PlatformDependentServices.Wifi;

namespace CSMobile.Presentation.Droid
{
    internal class AndroidModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterInstance(Android.App.Application.Context)
                .As<Context>()
                .SingleInstance();
            
            builder
                .RegisterSingleAsImplementedInterfaces<AndroidWifiManager>()
                .RegisterSingleAsImplementedInterfaces<AndroidCultureResolver>();
        }
    }
}
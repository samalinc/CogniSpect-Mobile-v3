using Autofac;

namespace CSMobile.Presentation.Views.AppContext
{
    public interface IApplicationContext
    {
        IContainer Container { get; }
    }
}
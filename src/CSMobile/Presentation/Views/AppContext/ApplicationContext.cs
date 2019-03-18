using IContainer = Autofac.IContainer;

namespace CSMobile.Presentation.Views.AppContext
{
    internal class ApplicationContext : IApplicationContext
    {
        public IContainer Container { get; set;  }
    }
}
using System.Collections.Generic;
using System.Reflection;
using Autofac;

namespace CSMobile.Infrastructure.Common.Autofac
{
    public class AssembliesRecorder
    {
        public AssembliesRecorder(ContainerBuilder containerBuilder)
        {
            Assemblies = new HashSet<Assembly>();
            ContainerBuilder = containerBuilder;
        }

        internal ICollection<Assembly> Assemblies { get; }

        internal ContainerBuilder ContainerBuilder { get; }
    }
}
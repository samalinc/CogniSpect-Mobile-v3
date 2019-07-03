using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using AutoMapper;
using AutoMapper.Configuration;
using CSMobile.Infrastructure.Common.Autofac;
using JetBrains.Annotations;

namespace CSMobile.Infrastructure.Common.Extensions
{
    public static class AssembliesRecorderExtensions
    {
        public static AssembliesRecorder AddCurrentDomainAssemblies(
            this AssembliesRecorder recorder,
            [NotNull] string filterName)
        {
            var assemblies = AppDomain.CurrentDomain
                .GetAssemblies()
                .Where(a => a.FullName.Contains(filterName))
                .ToArray();

            foreach (var assembly in assemblies)
            {
                recorder.Assemblies.Add(assembly);
            }

            return recorder;
        }

        public static AssembliesRecorder AddAssembly<T>(this AssembliesRecorder recorder)
        {
            recorder.Assemblies.Add(typeof(T).GetAssembly());

            return recorder;
        }

        public static AssembliesRecorder RegisterAssembliesModules(this AssembliesRecorder recorder)
        {
            recorder.ContainerBuilder.RegisterAssemblyModules(recorder.Assemblies.ToArray());
            return recorder;
        }

        public static AssembliesRecorder RegisterAutoMapper(this AssembliesRecorder recorder)
        {
            var builder = recorder.ContainerBuilder;

            builder
                .SingleFactoryAsSelf(context =>
                    new MapperConfiguration(cfg => cfg.AddProfiles(context.Resolve<IEnumerable<Profile>>())))
                .SingleFactoryAsSelf(context => context.Resolve<MapperConfiguration>().CreateMapper());

            builder
                .RegisterAssemblyTypes(recorder.Assemblies.ToArray())
                .AssignableTo<Profile>()
                .Except<MapperConfigurationExpression>()
                .Where(type => !type.IsNestedPrivate)
                .As<Profile>()
                .SingleInstance();

            return recorder;
        }

        public static ContainerBuilder ToContainerBuilder(this AssembliesRecorder recorder)
        {
            return recorder.ContainerBuilder;
        }
    }
}
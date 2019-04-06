using System;
using Autofac;
using AutoMapper;
using AutoMapper.Configuration;

namespace CSMobile.Infrastructure.Common.Extensions
{
    public static class AutomapperServicesRegistrationExtensions
    {
        public static ContainerBuilder RegisterAutomapper(this ContainerBuilder builder, Action<MapperConfigurationExpression> action)
        {
            var cfg = new MapperConfigurationExpression();
            action(cfg);
            
            var mapperConfiguration = new MapperConfiguration(cfg);
            mapperConfiguration.AssertConfigurationIsValid();
            
            // TODO: Need to think about less tricky solution
            builder.Register(c => mapperConfiguration.CreateMapper())
                .As<IMapper>()
                .SingleInstance();
            
            return builder;
        }

        public static MapperConfigurationExpression RegisterProfile<TProfile>(
            this MapperConfigurationExpression expression)
        where TProfile : Profile, new()
        {
            expression.AddProfile<TProfile>();
            
            return expression;
        }
    }
}
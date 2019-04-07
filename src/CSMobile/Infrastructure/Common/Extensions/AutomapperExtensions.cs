using Autofac.Core;
using AutoMapper;
using CommonServiceLocator;

namespace CSMobile.Infrastructure.Common.Extensions
{
    public static class AutomapperExtensions
    {
        public static IMappingExpression<TSource, TDestination> ConstructByDiContainer<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> mappingExpression)
        {
            // TODO: change to ISafeInjectionResolver (problem with resolving profile instance of automapper)
            mappingExpression.ConstructUsing(source => ServiceLocator.Current.GetInstance<TDestination>());

            return mappingExpression;
        }
        
        public static void IgnoreAllOther<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> mappingExpression)
        {
            mappingExpression.ForAllOtherMembers(d => d.Ignore());
        }
    }
}
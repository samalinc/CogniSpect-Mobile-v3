using System.Collections.Generic;
using CSMobile.Infrastructure.Mvvm.ViewModelsCore;
using JetBrains.Annotations;

namespace CSMobile.Infrastructure.Mvvm
{
    public interface IViewModelsFactory
    {
        /// <summary>
        /// Creates
        /// </summary>
        /// <param name="source"></param>
        /// <param name="page"></param>
        /// <typeparam name="TDestination">Destination type of view model</typeparam>
        /// <returns></returns>
        [NotNull]
        TDestination Create<TDestination>(
            [NotNull] object source,
            [NotNull] BasePageViewModel page)
            where TDestination : BaseViewModel;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="page"></param>
        /// <typeparam name="TDestination"></typeparam>
        /// <returns></returns>
        [NotNull]
        [ItemNotNull]
        IEnumerable<TDestination> Create<TDestination>(
            [NotNull] [ItemNotNull] IEnumerable<object> source,
            [NotNull] BasePageViewModel page)
            where TDestination : BaseViewModel;
    }
}
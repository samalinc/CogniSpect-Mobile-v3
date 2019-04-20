using System.Collections.Generic;
using AutoMapper;
using CSMobile.Application.ViewModels.ViewModels.Core;
using Xamarin.Forms.Internals;

namespace CSMobile.Application.ViewModels.ViewModels
{
    internal class ViewModelsFactory : IViewModelsFactory
    {
        private readonly IMapper _mapper;

        public ViewModelsFactory(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TDestination Create<TDestination>(
            object source,
            BasePageViewModel page)
            where TDestination : BaseViewModel
        {
            TDestination result = _mapper.Map<TDestination>(source);
            SetHandlers(result, page);

            return result;
        }

        public IEnumerable<TDestination> Create<TDestination>(
            IEnumerable<object> source,
            BasePageViewModel page)
            where TDestination : BaseViewModel
        {
            IEnumerable<TDestination> result = _mapper.Map<IEnumerable<TDestination>>(source);
            result.ForEach((v) => SetHandlers(v, page));

            return result;
        }

        private void SetHandlers<TDestination, TPageViewModel>(TDestination destination, TPageViewModel page)
            where TDestination : BaseViewModel
            where TPageViewModel : BasePageViewModel
        {
            destination.OnCommandStarted += page.OnCommandStartedHandler;
            destination.OnCommandEnded += page.OnCommandEndedHandler;
            destination.OnCommandFinal += page.OnCommandFinalHandler;
            destination.OnCommandExceptionHappened +=  page.OnCommandExceptionHappenedFinalHandler;
        }
    }
}
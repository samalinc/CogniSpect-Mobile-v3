using System.Collections.Generic;
using System.Linq;
using Autofac;
using AutoMapper;
using CSMobile.Infrastructure.Common;
using CSMobile.Infrastructure.Mvvm.ViewModelsCore;

namespace CSMobile.Infrastructure.Mvvm
{
    internal class ViewModelsFactory : IViewModelsFactory
    {
        private readonly IMapper _mapper;
        private readonly ISafeInjectionResolver _safeInjectionResolver;

        public ViewModelsFactory(IMapper mapper,
            ISafeInjectionResolver safeInjectionResolver)
        {
            _mapper = mapper;
            _safeInjectionResolver = safeInjectionResolver;
        }

        public TDestination Create<TDestination>(
            object source,
            BasePageViewModel page)
            where TDestination : BaseViewModel
        {
            TDestination result = CreateRaw<TDestination>(page);

            return _mapper.Map(source, result);
        }

        public IEnumerable<TDestination> Create<TDestination>(
            IEnumerable<object> source,
            BasePageViewModel page)
            where TDestination : BaseViewModel
        {
            return source.Select(s => Create<TDestination>(s, page)).ToArray();
        }
        
        private TDestination CreateRaw<TDestination>(BasePageViewModel page)
        {
            return _safeInjectionResolver
                .ResolveService<TDestination>(new TypedParameter(typeof(BasePageViewModel),
                    page));
        }
    }
}
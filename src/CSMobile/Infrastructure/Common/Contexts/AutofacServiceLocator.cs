using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Core;
using CommonServiceLocator;

namespace CSMobile.Infrastructure.Common.Contexts
{
    public class AutofacServiceLocator : IServiceLocator, ISafeInjectionResolver
    {
        private readonly ApplicationContext _context;

        private ILifetimeScope Container => _context.UserContext?.Scope ?? _context.Container;

        public AutofacServiceLocator(ApplicationContext context)
        {
            _context = context;
        }

        public object GetService(Type serviceType)
        {
            return GetInstance(serviceType);
        }

        public object GetInstance(Type serviceType)
        {
            return Container.Resolve(serviceType);
        }

        public object GetInstance(Type serviceType, string key)
        {
            try
            {
                return Container.ResolveKeyed(key, serviceType);
            }
            catch (Exception ex)
            {
                throw new ActivationException("ActivationException", ex);
            }
        }

        public IEnumerable<object> GetAllInstances(Type serviceType)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                throw new ActivationException("ActivationException", ex);
            }
        }

        public TService GetInstance<TService>()
        {
            return (TService) GetInstance(typeof(TService));
        }

        public TService GetInstance<TService>(string key)
        {
            return (TService) GetInstance(typeof(TService), key);
        }

        public IEnumerable<TService> GetAllInstances<TService>()
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                throw new ActivationException("ActivationException", ex);
            }
        }

        public TService ResolveService<TService>()
        {
            return GetInstance<TService>();
        }

        public TService ResolveService<TService>(params Parameter[] parameters)
        {
            return Container.Resolve<TService>(parameters);
        }
    }
}
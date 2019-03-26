using System;
using System.Collections.Generic;
using Autofac;
using CommonServiceLocator;

namespace CSMobile.Infrastructure.Services
{
    public class AutofacServiceLocator : IServiceLocator
    {
        private readonly IContainer _container;

        public AutofacServiceLocator(Action<ContainerBuilder> builder)
        {
            var containerBuilder = new ContainerBuilder();
            builder(containerBuilder);
            _container = containerBuilder.Build();
        }

        public object GetService(Type serviceType)
        {
            return GetInstance(serviceType);
        }

        public object GetInstance(Type serviceType)
        {
            return _container.Resolve(serviceType);
        }

        public object GetInstance(Type serviceType, string key)
        {
            try
            {
                return _container.ResolveKeyed(key, serviceType);
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
    }
}
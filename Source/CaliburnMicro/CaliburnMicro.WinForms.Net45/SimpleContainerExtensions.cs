namespace MvvmFx.CaliburnMicro
{
    using System;
    using System.Reflection;
    using System.Linq;

    /// <summary>
    /// Extension methods for the simple IoC container.
    /// </summary>
    public static class SimpleContainerExtensions
    {
        /// <summary>
        /// Registers the specified object as Singleton, on the specified container.
        /// </summary>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="container">The container.</param>
        /// <returns>The container.</returns>
        public static SimpleContainer Singleton<TImplementation>(this SimpleContainer container)
        {
            container.RegisterSingleton(typeof(TImplementation), null, typeof(TImplementation));
            return container;
        }

        /// <summary>
        /// Registers the specified object as Singleton using the default constructor, on the specified container.
        /// </summary>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="container">The container.</param>
        /// <returns>The container.</returns>
        public static SimpleContainer SingletonWithDefaultCtor<TImplementation>(this SimpleContainer container)
        {
            container.RegisteSingletonWithDefaultCtor(typeof(TImplementation), null, typeof(TImplementation));
            return container;
        }

        /// <summary>
        /// Registers the specified object and service as Singleton, on the specified container.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="container">The container.</param>
        /// <returns>The container.</returns>
        public static SimpleContainer Singleton<TService, TImplementation>(this SimpleContainer container)
            where TImplementation : TService
        {
            container.RegisterSingleton(typeof(TService), null, typeof(TImplementation));
            return container;
        }

        /// <summary>
        /// Registers the specified object and service as Singleton using the default constructor, on the specified container.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="container">The container.</param>
        /// <returns>The container.</returns>
        public static SimpleContainer SingletonWithDefaultCtor<TService, TImplementation>(
            this SimpleContainer container)
            where TImplementation : TService
        {
            container.RegisteSingletonWithDefaultCtor(typeof(TService), null, typeof(TImplementation));
            return container;
        }

        /// <summary>
        /// Registers the specified object and service per request, on the specified container.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="container">The container.</param>
        /// <returns>The container.</returns>
        public static SimpleContainer PerRequest<TService, TImplementation>(this SimpleContainer container)
            where TImplementation : TService
        {
            container.RegisterPerRequest(typeof(TService), null, typeof(TImplementation));
            return container;
        }

        /// <summary>
        /// Registers the specified object and service per request, using the default constructor, on the specified container.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="container">The container.</param>
        /// <returns>The container.</returns>
        public static SimpleContainer PerRequestWithDefaultCtor<TService, TImplementation>(
            this SimpleContainer container)
            where TImplementation : TService
        {
            container.RegisterPerRequestWithDefaultCtor(typeof(TService), null, typeof(TImplementation));
            return container;
        }

        /// <summary>
        /// Registers the specified object per request, on the specified container.
        /// </summary>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="container">The container.</param>
        /// <returns>The container.</returns>
        public static SimpleContainer PerRequest<TImplementation>(this SimpleContainer container)
        {
            container.RegisterPerRequest(typeof(TImplementation), null, typeof(TImplementation));
            return container;
        }

        /// <summary>
        /// Registers the specified object per request, using the default constructor, on the specified container.
        /// </summary>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="container">The container.</param>
        /// <returns>The container.</returns>
        public static SimpleContainer PerRequestWithDefaultCtor<TImplementation>(this SimpleContainer container)
        {
            container.RegisterPerRequestWithDefaultCtor(typeof(TImplementation), null, typeof(TImplementation));
            return container;
        }

        /// <summary>
        /// Registers the service on the specified container.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="container">The container.</param>
        /// <param name="instance">The instance.</param>
        /// <returns>The container.</returns>
        public static SimpleContainer Instance<TService>(this SimpleContainer container, TService instance)
        {
            container.RegisterInstance(typeof(TService), null, instance);
            return container;
        }

        /// <summary>
        /// Registers a custom handler for serving requests on the specified container.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="container">The container.</param>
        /// <param name="handler">The handler.</param>
        /// <returns>The container.</returns>
        public static SimpleContainer Handler<TService>(this SimpleContainer container,
            Func<SimpleContainer, object> handler)
        {
            container.RegisterHandler(typeof(TService), null, handler);
            return container;
        }

        /// <summary>
        /// Requests an instance on the specified container.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="container">The container.</param>
        /// <returns>The service.</returns>
        public static TService GetInstance<TService>(this SimpleContainer container)
        {
            return (TService) container.GetInstance(typeof(TService), null);
        }

        /// <summary>
        /// Registers all types of the specified service, of the specified Assembly, per request, on the specified container.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="container">The container.</param>
        /// <param name="assembly">The assembly.</param>
        /// <param name="filter">The filter.</param>
        /// <returns>The container.</returns>
        public static SimpleContainer AllTypesOf<TService>(this SimpleContainer container, Assembly assembly,
            Func<Type, bool> filter = null)
        {
            if (null == filter)
            {
                filter = type => true;
            }

            var types = from type in assembly.GetTypes()
                where typeof(TService).IsAssignableFrom(type)
                      && !type.IsAbstract
                      && !type.IsInterface
                      && filter(type)
                select type;

            foreach (var type in types)
            {
                container.RegisterPerRequest(typeof(TService), null, type);
            }

            return container;
        }

        /// <summary>
        /// Registers all types of the specified Assembly, as Singleton, on the specified container.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="container">The container.</param>
        /// <param name="assembly">The assembly.</param>
        /// <param name="filter">The filter.</param>
        /// <returns>The container.</returns>
        public static SimpleContainer AllTypesOfAsSingleton<TService>(this SimpleContainer container, Assembly assembly,
            Func<Type, bool> filter = null)
        {
            return AllTypesOfAsSingleton(container, typeof(TService), assembly, filter);
        }

        /// <summary>
        /// Registers all types of the specified Assembly, as Singleton, on the specified container.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="assembly">The assembly.</param>
        /// <param name="filter">The filter.</param>
        /// <returns>The container.</returns>
        public static SimpleContainer AllTypesOfAsSingleton(this SimpleContainer container, Type serviceType,
            Assembly assembly, Func<Type, bool> filter = null)
        {
            if (null == filter)
            {
                filter = type => true;
            }

            var types = from type in assembly.GetTypes()
                where serviceType.IsAssignableFrom(type)
                      && !type.IsAbstract
                      && !type.IsInterface
                      && filter(type)
                select type;

            foreach (var type in types)
            {
                container.RegisterSingleton(serviceType, null, type);
            }

            return container;
        }
    }
}
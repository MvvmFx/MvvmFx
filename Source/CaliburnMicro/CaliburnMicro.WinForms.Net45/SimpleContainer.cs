﻿namespace MvvmFx.CaliburnMicro
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Linq;

    /// <summary>
    /// A simple IoC container.
    /// </summary>
    public class SimpleContainer
    {
        private readonly List<ContainerEntry> _entries;

        /// <summary>
        /// Initializes a new instance of the <see cref = "SimpleContainer" /> class.
        /// </summary>
        public SimpleContainer()
            : this(null)
        {
        }

        private SimpleContainer(IEnumerable<ContainerEntry> entries)
        {
            _entries =
                (null != entries)
                    ? _entries = new List<ContainerEntry>(entries)
                    : new List<ContainerEntry>();
        }

        /// <summary>
        /// Registers the instance.
        /// </summary>
        /// <param name = "service">The service.</param>
        /// <param name = "key">The key.</param>
        /// <param name = "implementation">The implementation.</param>
        public void RegisterInstance(Type service, string key, object implementation)
        {
            RegisterHandler(service, key, container => implementation);
        }

        /// <summary>
        /// Registers the class so that a new instance is created on every request.
        /// </summary>
        /// <param name = "service">The service.</param>
        /// <param name = "key">The key.</param>
        /// <param name = "implementation">The implementation.</param>
        public void RegisterPerRequest(Type service, string key, Type implementation)
        {
            RegisterHandler(service, key, container => container.BuildInstance(implementation));
        }

        /// <summary>
        /// Registers the class so that a new instance is created on every request using the default constructor.
        /// </summary>
        /// <param name = "service">The service.</param>
        /// <param name = "key">The key.</param>
        /// <param name = "implementation">The implementation.</param>
        public void RegisterPerRequestWithDefaultCtor(Type service, string key, Type implementation)
        {
            RegisterHandler(service, key, container => container.BuildInstanceWithDefaultCtor(implementation));
        }

        /// <summary>
        /// Registers the class so that it is created once, on first request using the default constructor,
        /// and the same instance is returned to all requestors thereafter.
        /// </summary>
        /// <param name = "service">The service.</param>
        /// <param name = "key">The key.</param>
        /// <param name = "implementation">The implementation.</param>
        public void RegisterSingleton(Type service, string key, Type implementation)
        {
            object singleton = null;
            RegisterHandler(service, key,
                container => singleton ?? (singleton = container.BuildInstance(implementation)));
        }

        /// <summary>
        /// Registers the class so that it is created once, on first request,
        /// and the same instance is returned to all requestors thereafter.
        /// </summary>
        /// <param name = "service">The service.</param>
        /// <param name = "key">The key.</param>
        /// <param name = "implementation">The implementation.</param>
        public void RegisteSingletonWithDefaultCtor(Type service, string key, Type implementation)
        {
            object singleton = null;
            RegisterHandler(service, key,
                container => singleton ?? (singleton = container.BuildInstanceWithDefaultCtor(implementation)));
        }

        /// <summary>
        /// Registers a custom handler for serving requests from the container.
        /// </summary>
        /// <param name = "service">The service.</param>
        /// <param name = "key">The key.</param>
        /// <param name = "handler">The handler.</param>
        public void RegisterHandler(Type service, string key, Func<SimpleContainer, object> handler)
        {
            GetOrCreateEntry(service, key).Add(handler);
        }

        /// <summary>
        /// Requests an instance.
        /// </summary>
        /// <param name = "service">The service.</param>
        /// <param name = "key">The key.</param>
        /// <returns>The instance, or null if a handler is not found.</returns>
        public object GetInstance(Type service, string key)
        {
            var entry = GetEntry(service, key);

            if (null != entry)
            {
                return entry.Single()(this);
            }

            if (typeof(Delegate).IsAssignableFrom(service))
            {
                var typeToCreate = service.GetGenericArguments()[0];
                var factoryFactoryType = typeof(FactoryFactory<>).MakeGenericType(typeToCreate);
                var factoryFactoryHost = Activator.CreateInstance(factoryFactoryType);
                var factoryFactoryMethod = factoryFactoryType.GetMethod("Create");
                return factoryFactoryMethod.Invoke(factoryFactoryHost, new object[] {this});
            }

            if (typeof(IEnumerable).IsAssignableFrom(service))
            {
                var listType = service.GetGenericArguments()[0];
                var instances = GetAllInstances(listType).ToList();
                var array = Array.CreateInstance(listType, instances.Count);

                for (var index = 0; index < array.Length; index++)
                {
                    array.SetValue(instances[index], index);
                }

                return array;
            }

            return null;
        }

        /// <summary>
        /// Requests all instances of a given type.
        /// </summary>
        /// <param name = "service">The service.</param>
        /// <returns>All the instances or an empty enumerable if none are found.</returns>
        public IEnumerable<object> GetAllInstances(Type service)
        {
            var entry = GetEntry(service, null);
            return (null != entry) ? entry.Select(x => x(this)) : new object[0];
        }

        /// <summary>
        /// Pushes dependencies into an existing instance based on interface properties with setters.
        /// </summary>
        /// <param name = "instance">The instance.</param>
        public void BuildUp(object instance)
        {
            var injectables = from property in instance.GetType().GetProperties()
                where property.CanRead && property.CanWrite && property.PropertyType.IsInterface
                select property;

            foreach (var propertyInfo in injectables)
            {
                var injection = GetAllInstances(propertyInfo.PropertyType).ToArray();
                if (injection.Any())
                {
                    propertyInfo.SetValue(instance, injection.First(), null);
                }
            }
        }

        /// <summary>
        /// Creates a child container.
        /// </summary>
        /// <returns>A new container.</returns>
        public SimpleContainer CreateChildContainer()
        {
            return new SimpleContainer(_entries);
        }

        /// <summary>
        /// Actually does the work of creating the instance and satisfying it's constructor dependencies.
        /// </summary>
        /// <param name = "type">The type.</param>
        /// <returns>The created instance-</returns>
        protected object BuildInstance(Type type)
        {
            var args = DetermineConstructorArgs(type);
            return ActivateInstance(type, args);
        }

        /// <summary>
        /// Creates an instance of the type with the specified constructor arguments.
        /// </summary>
        /// <param name = "type">The type.</param>
        /// <param name = "args">The constructor args.</param>
        /// <returns>The created instance.</returns>
        protected virtual object ActivateInstance(Type type, object[] args)
        {
            var instance = args.Length > 0 ? Activator.CreateInstance(type, args) : Activator.CreateInstance(type);
            Activated(instance);
            return instance;
        }

        /// <summary>
        /// Occurs when a new instance is created.
        /// </summary>
        public event Action<object> Activated = delegate { };

        private object[] DetermineConstructorArgs(Type implementation)
        {
            var args = new List<object>();
            var constructor = SelectEligibleConstructor(implementation);

            if (null != constructor)
            {
                args.AddRange(constructor.GetParameters().Select(info => GetInstance(info.ParameterType, null)));
            }

            return args.ToArray();
        }

        private ContainerEntry GetOrCreateEntry(Type service, string key)
        {
            var entry = GetEntry(service, key);
            if (null == entry)
            {
                entry = new ContainerEntry {Service = service, Key = key};
                _entries.Add(entry);
            }

            return entry;
        }

        private ContainerEntry GetEntry(Type service, string key)
        {
            return (null == service)
                ? _entries.Where(x => x.Key == key).FirstOrDefault()
                : _entries.Where(x => x.Service == service && x.Key == key).FirstOrDefault();
        }

        private object BuildInstanceWithDefaultCtor(Type type)
        {
            return ActivateInstance(type, new object[] { });
        }

        private static ConstructorInfo SelectEligibleConstructor(Type type)
        {
            return (from c in type.GetConstructors()
                orderby c.GetParameters().Length descending
                select c).FirstOrDefault();
        }

        private class ContainerEntry : List<Func<SimpleContainer, object>>
        {
            public string Key;
            public Type Service;
        }

        private class FactoryFactory<T>
        {
            public Func<T> Create(SimpleContainer container)
            {
                return () => (T) container.GetInstance(typeof(T), null);
            }
        }
    }
}
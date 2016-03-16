using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using Kent.Boogaart.HelperTrinity.Extensions;

namespace Kent.Boogaart.HelperTrinity
{
    /// <summary>
    /// Provides helper methods for raising exceptions.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The <c>ExceptionHelper</c> class provides a centralised mechanism for throwing exceptions. This helps to keep exception
    /// messages and types consistent.
    /// </para>
    /// <para>
    /// Exception information is stored in an embedded resource called <c>ExceptionHelper.xml</c>, which must reside in the
    /// <c>Properties</c> namespace for the assembly in which the for type is stored. For example, if the root namespace for
    /// an assembly is <c>Company.Product</c> then the exception information must be stored in a resource called
    /// <c>Company.Product.Properties.ExceptionHelper.xml</c>
    /// </para>
    /// <para>
    /// The format for the exception information XML includes a grouping mechanism such that exception keys are scoped to the
    /// type throwing the exception. Thus, different types can use the same exception key because they have different scopes in
    /// the XML structure. An example of the format for the exception XML can be seen below.
    /// </para>
    /// <note type="implementation">
    /// This class is designed to be efficient in the common case (ie. no exception thrown) but is quite inefficient if an
    /// exception is actually thrown. This is not considered a problem, however, since an exception usually indicates that
    /// execution cannot reliably continue.
    /// </note>
    /// </remarks>
    /// <example>
    /// The following example shows how an exception can thrown:
    /// <code>
    /// var exceptionHelper = new ExceptionHelper(typeof(Bar));
    /// throw exceptionHelper.Resolve("myKey", "hello");
    /// </code>
    /// Assuming this code resides in a class called <c>Foo.Bar</c>, the XML configuration might look like this:
    /// <code>
    /// <![CDATA[
    /// <?xml version="1.0" encoding="utf-8" ?>
    ///
    /// <exceptionHelper>
    /// 	<exceptionGroup type="Foo.Bar">
    /// 		<exception key="myKey" type="System.NullReferenceException">
    /// 			Foo is null but I'll say '{0}' anyway.
    /// 		</exception>
    /// 	</exceptionGroup>
    /// </exceptionHelper>
    /// ]]>
    /// </code>
    /// With this configuration, a <see cref="NullReferenceException"/> will be thrown. The exception message will be
    /// "Foo is null but I'll say 'hello' anyway.".
    /// </example>
    /// <example>
    /// The following example shows how an exception can be conditionally thrown:
    /// <code>
    /// var exceptionHelper = new ExceptionHelper(typeof(Bar));
    /// exceptionHelper.ResolveAndThrowIf(foo == null, "myKey", "hello");
    /// </code>
    /// Assuming this code resides in a class called <c>Foo.Bar</c>, the XML configuration might look like this:
    /// <code>
    /// <![CDATA[
    /// <?xml version="1.0" encoding="utf-8" ?>
    ///
    /// <exceptionHelper>
    /// 	<exceptionGroup type="Foo.Bar">
    /// 		<exception key="myKey" type="System.NullReferenceException">
    /// 			Foo is null but I'll say '{0}' anyway.
    /// 		</exception>
    /// 	</exceptionGroup>
    /// </exceptionHelper>
    /// ]]>
    /// </code>
    /// With this configuration, a <see cref="NullReferenceException"/> will be thrown if <c>foo</c> is <see langword="null"/>.
    /// The exception message will be "Foo is null but I'll say 'hello' anyway.".
    /// </example>
    internal class ExceptionHelper
    {
        private static readonly IDictionary<Assembly, XDocument> _exceptionInfos = new Dictionary<Assembly, XDocument>();
        private static readonly object _exceptionInfosLock = new object();
        private readonly Type _forType;
        private const string _typeAttributeName = "type";

        /// <summary>
        /// Initializes a new instance of the <c>ExceptionHelper</c> class.
        /// </summary>
        /// <param name="forType">
        /// The type for which exceptions will be resolved.
        /// </param>
        internal ExceptionHelper(Type forType)
        {
            forType.AssertNotNull("forType");
            _forType = forType;
        }

        /// <summary>
        /// Resolves an exception.
        /// </summary>
        /// <param name="exceptionKey">
        /// The exception key.
        /// </param>
        /// <param name="messageArgs">
        /// Arguments to be substituted into the resolved exception's message.
        /// </param>
        /// <returns>
        /// The resolved exception.
        /// </returns>
        [DebuggerHidden]
        internal Exception Resolve(string exceptionKey, params object[] messageArgs)
        {
            return Resolve(exceptionKey, null, null, messageArgs);
        }

        /// <summary>
        /// Resolves an exception.
        /// </summary>
        /// <param name="exceptionKey">
        /// The exception key.
        /// </param>
        /// <param name="innerException">
        /// The inner exception of the resolved exception.
        /// </param>
        /// <param name="messageArgs">
        /// Arguments to be substituted into the resolved exception's message.
        /// </param>
        /// <returns>
        /// The resolved exception.
        /// </returns>
        [DebuggerHidden]
        internal Exception Resolve(string exceptionKey, Exception innerException, params object[] messageArgs)
        {
            return Resolve(exceptionKey, null, innerException, messageArgs);
        }

        /// <summary>
        /// Resolves an exception.
        /// </summary>
        /// <param name="exceptionKey">
        /// The exception key.
        /// </param>
        /// <param name="constructorArgs">
        /// Additional arguments for the resolved exception's constructor.
        /// </param>
        /// <param name="innerException">
        /// The inner exception of the resolved exception.
        /// </param>
        /// <returns>
        /// The resolved exception.
        /// </returns>
        [DebuggerHidden]
        internal Exception Resolve(string exceptionKey, object[] constructorArgs, Exception innerException)
        {
            return Resolve(exceptionKey, constructorArgs, innerException, null);
        }

        /// <summary>
        /// Resolves an exception.
        /// </summary>
        /// <param name="exceptionKey">
        /// The exception key.
        /// </param>
        /// <param name="constructorArgs">
        /// Additional arguments for the resolved exception's constructor.
        /// </param>
        /// <param name="messageArgs">
        /// Arguments to be substituted into the resolved exception's message.
        /// </param>
        /// <returns>
        /// The resolved exception.
        /// </returns>
        [DebuggerHidden]
        internal Exception Resolve(string exceptionKey, object[] constructorArgs, params object[] messageArgs)
        {
            return Resolve(exceptionKey, constructorArgs, null, messageArgs);
        }

        /// <summary>
        /// Resolves an exception.
        /// </summary>
        /// <param name="exceptionKey">
        /// The exception key.
        /// </param>
        /// <param name="constructorArgs">
        /// Additional arguments for the resolved exception's constructor.
        /// </param>
        /// <param name="innerException">
        /// The inner exception of the resolved exception.
        /// </param>
        /// <param name="messageArgs">
        /// Arguments to be substituted into the resolved exception's message.
        /// </param>
        /// <returns>
        /// The resolved exception.
        /// </returns>
        [DebuggerHidden]
        internal Exception Resolve(string exceptionKey, object[] constructorArgs, Exception innerException, params object[] messageArgs)
        {
            exceptionKey.AssertNotNull("exceptionKey");

            var exceptionInfo = GetExceptionInfo(_forType.Assembly);
            var exceptionNode = (from exceptionGroup in exceptionInfo.Element("exceptionHelper").Elements("exceptionGroup")
                                 from exception in exceptionGroup.Elements("exception")
                                 where string.Equals(exceptionGroup.Attribute("type").Value, _forType.FullName, StringComparison.Ordinal) && string.Equals(exception.Attribute("key").Value, exceptionKey, StringComparison.Ordinal)
                                 select exception).FirstOrDefault();

            if (exceptionNode == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "The exception details for key '{0}' could not be found at /exceptionHelper/exceptionGroup[@type'{1}']/exception[@key='{2}'].", exceptionKey, _forType, exceptionKey));
            }

            var typeAttribute = exceptionNode.Attribute(_typeAttributeName);

            if (typeAttribute == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "The '{0}' attribute could not be found for exception with key '{1}'", _typeAttributeName, exceptionKey));
            }

            var type = Type.GetType(typeAttribute.Value);

            if (type == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Type '{0}' could not be loaded for exception with key '{1}'", typeAttribute.Value, exceptionKey));
            }

            if (!typeof(Exception).IsAssignableFrom(type))
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Type '{0}' for exception with key '{1}' does not inherit from '{2}'", type.FullName, exceptionKey, typeof(Exception).FullName));
            }

            var message = exceptionNode.Value.Trim();

            if ((messageArgs != null) && (messageArgs.Length > 0))
            {
                message = string.Format(CultureInfo.InvariantCulture, message, messageArgs);
            }

            var constructorArgsList = new List<object>();
            // message is always first
            constructorArgsList.Add(message);

            // next, any additional constructor args
            if (constructorArgs != null)
            {
                constructorArgsList.AddRange(constructorArgs);
            }

            // finally, the inner exception, if any
            if (innerException != null)
            {
                constructorArgsList.Add(innerException);
            }

            var constructorArgsArr = constructorArgsList.ToArray();
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;
            ConstructorInfo constructor = null;

            try
            {
                object state;
                constructor = (ConstructorInfo)Type.DefaultBinder.BindToMethod(bindingFlags, type.GetConstructors(bindingFlags), ref constructorArgsArr, null, null, null, out state);
            }
            catch (MissingMethodException)
            {
                //swallow and deal with below
            }

            if (constructor == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "An appropriate constructor could not be found for exception type '{0}, for exception with key '{1}'", type.FullName, exceptionKey));
            }

            return (Exception)constructor.Invoke(constructorArgsArr);
        }

        /// <summary>
        /// Resolves and throws the specified exception if the given condition is met.
        /// </summary>
        /// <param name="condition">
        /// The condition that determines whether the exception will be resolved and thrown.
        /// </param>
        /// <param name="exceptionKey">
        /// The exception key.
        /// </param>
        /// <param name="messageArgs">
        /// Arguments to be substituted into the resolved exception's message.
        /// </param>
        [DebuggerHidden]
        internal void ResolveAndThrowIf(bool condition, string exceptionKey, params object[] messageArgs)
        {
            if (condition)
            {
                throw Resolve(exceptionKey, messageArgs);
            }
        }

        /// <summary>
        /// Resolves and throws the specified exception if the given condition is met.
        /// </summary>
        /// <param name="condition">
        /// The condition that determines whether the exception will be resolved and thrown.
        /// </param>
        /// <param name="exceptionKey">
        /// The exception key.
        /// </param>
        /// <param name="innerException">
        /// The inner exception of the resolved exception.
        /// </param>
        /// <param name="messageArgs">
        /// Arguments to be substituted into the resolved exception's message.
        /// </param>
        [DebuggerHidden]
        internal void ResolveAndThrowIf(bool condition, string exceptionKey, Exception innerException, params object[] messageArgs)
        {
            if (condition)
            {
                throw Resolve(exceptionKey, innerException, messageArgs);
            }
        }

        /// <summary>
        /// Resolves and throws the specified exception if the given condition is met.
        /// </summary>
        /// <param name="condition">
        /// The condition that determines whether the exception will be resolved and thrown.
        /// </param>
        /// <param name="exceptionKey">
        /// The exception key.
        /// </param>
        /// <param name="constructorArgs">
        /// Additional arguments for the resolved exception's constructor.
        /// </param>
        /// <param name="innerException">
        /// The inner exception of the resolved exception.
        /// </param>
        [DebuggerHidden]
        internal void ResolveAndThrowIf(bool condition, string exceptionKey, object[] constructorArgs, Exception innerException)
        {
            if (condition)
            {
                throw Resolve(exceptionKey, constructorArgs, innerException);
            }
        }

        /// <summary>
        /// Resolves and throws the specified exception if the given condition is met.
        /// </summary>
        /// <param name="condition">
        /// The condition that determines whether the exception will be resolved and thrown.
        /// </param>
        /// <param name="exceptionKey">
        /// The exception key.
        /// </param>
        /// <param name="constructorArgs">
        /// Additional arguments for the resolved exception's constructor.
        /// </param>
        /// <param name="messageArgs">
        /// Arguments to be substituted into the resolved exception's message.
        /// </param>
        [DebuggerHidden]
        internal void ResolveAndThrowIf(bool condition, string exceptionKey, object[] constructorArgs, params object[] messageArgs)
        {
            if (condition)
            {
                throw Resolve(exceptionKey, constructorArgs, messageArgs);
            }
        }

        /// <summary>
        /// Resolves and throws the specified exception if the given condition is met.
        /// </summary>
        /// <param name="condition">
        /// The condition that determines whether the exception will be resolved and thrown.
        /// </param>
        /// <param name="exceptionKey">
        /// The exception key.
        /// </param>
        /// <param name="constructorArgs">
        /// Additional arguments for the resolved exception's constructor.
        /// </param>
        /// <param name="innerException">
        /// The inner exception of the resolved exception.
        /// </param>
        /// <param name="messageArgs">
        /// Arguments to be substituted into the resolved exception's message.
        /// </param>
        [DebuggerHidden]
        internal void ResolveAndThrowIf(bool condition, string exceptionKey, object[] constructorArgs, Exception innerException, params object[] messageArgs)
        {
            if (condition)
            {
                throw Resolve(exceptionKey, constructorArgs, innerException, messageArgs);
            }
        }

        [DebuggerHidden]
        private static XDocument GetExceptionInfo(Assembly assembly)
        {
            var retVal = (XDocument)null;

            lock (_exceptionInfosLock)
            {
                if (_exceptionInfos.ContainsKey(assembly))
                {
                    retVal = _exceptionInfos[assembly];
                }
                else
                {
                    var assemblyName = new AssemblyName(assembly.FullName);

                    // if the exception info isn't cached we have to load it from an embedded resource in the calling assembly
                    var resourceName = string.Concat(assemblyName.Name, ".Properties.ExceptionHelper.xml");

                    using (var stream = assembly.GetManifestResourceStream(resourceName))
                    {
                        if (stream == null)
                        {
                            throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "XML resource file '{0}' could not be found in assembly '{1}'.", resourceName, assembly.FullName));
                        }

                        using (var streamReader = new StreamReader(stream))
                        {
                            retVal = XDocument.Load(streamReader);
                        }
                    }

                    _exceptionInfos[assembly] = retVal;
                }
            }

            return retVal;
        }
    }
}

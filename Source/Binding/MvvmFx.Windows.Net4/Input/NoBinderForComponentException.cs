using System;

namespace MvvmFx.Windows.Input
{
    /// <summary>
    /// Represents the error that occur when no binder is found for a given <see cref="System.ComponentModel.IComponent"/>.
    /// </summary>
    [Serializable]
    public class NoBinderForComponentException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoBinderForComponentException"/> class.
        /// </summary>
        public NoBinderForComponentException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NoBinderForComponentException"/> class
        /// with a specified error message.
        /// </summary>
        /// <param name="message">The message.</param>
        public NoBinderForComponentException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NoBinderForComponentException"/> class
        /// with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner exception.</param>
        public NoBinderForComponentException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NoBinderForComponentException"/> class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="info"/> parameter is null. </exception>
        ///
        /// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"/> is zero (0). </exception>
        protected NoBinderForComponentException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}
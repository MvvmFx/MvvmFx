﻿// ****************************************************************************
// <copyright file="ViewModelBase.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009-2012
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>22.4.2009</date>
// <project>GalaSoft.MvvmLight</project>
// <web>http://www.galasoft.ch</web>
// <license>
// See license.txt in this project or http://www.galasoft.ch/license_MIT.txt
// </license>
// <LastBaseLevel>BL0014</LastBaseLevel>
// ****************************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using MvvmFx.MvvmLight.Messaging;
using System.Linq.Expressions;

////using GalaSoft.Utilities.Attributes;

namespace MvvmFx.MvvmLight
{
    /// <summary>
    /// A base class for the ViewModel classes in the MVVM pattern.
    /// </summary>
    //// [ClassInfo(typeof(ViewModelBase),
    ////  VersionString = "4.0.14",
    ////  DateString = "201206191330",
    ////  Description = "A base class for the ViewModel classes in the MVVM pattern.",
    ////  UrlContacts = "http://www.galasoft.ch/contact_en.html",
    ////  Email = "laurent@galasoft.ch")]
    [SuppressMessage("Microsoft.Design", "CA1012", Justification = "Constructors should remain public to allow serialization.")]
    public abstract class ViewModelBase : ObservableObject, ICleanup
    {
//        private static bool? _isInDesignMode;
        private IMessenger _messengerInstance;

        /// <summary>
        /// Initializes a new instance of the ViewModelBase class.
        /// </summary>
        public ViewModelBase()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ViewModelBase class.
        /// </summary>
        /// <param name="messenger">An instance of a <see cref="Messenger" />
        /// used to broadcast messages to other objects. If null, this class
        /// will attempt to broadcast using the Messenger's default
        /// instance.</param>
        public ViewModelBase(IMessenger messenger)
        {
            MessengerInstance = messenger;
        }

        /// <summary>
        /// Gets a value indicating whether the control is in design mode
        /// (running under Blend or Visual Studio).
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Non static member needed for data binding")]
        public bool IsInDesignMode
        {
            get
            {
                return IsInDesignModeStatic;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the control is in design mode
        /// (running in Blend or Visual Studio).
        /// </summary>
        [SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands", Justification = "The security risk here is neglectible.")]
        public static bool IsInDesignModeStatic
        {
            get
            {
#if WINFORMS || WEBGUI
                return false;
#else
                if (!_isInDesignMode.HasValue)
                {
#if SILVERLIGHT
                    _isInDesignMode = DesignerProperties.IsInDesignTool;
#else
#if NETFX_CORE
                    _isInDesignMode = Windows.ApplicationModel.DesignMode.DesignModeEnabled;
#else
                    var prop = DesignerProperties.IsInDesignModeProperty;
                    _isInDesignMode
                        = (bool)DependencyPropertyDescriptor
                                     .FromProperty(prop, typeof(FrameworkElement))
                                     .Metadata.DefaultValue;
#endif
#endif
                }

                return _isInDesignMode.Value;
#endif
            }
        }

        /// <summary>
        /// Gets or sets an instance of a <see cref="IMessenger" /> used to
        /// broadcast messages to other objects. If null, this class will
        /// attempt to broadcast using the Messenger's default instance.
        /// </summary>
        protected IMessenger MessengerInstance
        {
            get
            {
                return _messengerInstance ?? Messenger.Default;
            }
            set
            {
                _messengerInstance = value;
            }
        }

        /// <summary>
        /// Unregisters this instance from the Messenger class.
        /// <para>To cleanup additional resources, override this method, clean
        /// up and then call base.Cleanup().</para>
        /// </summary>
        public virtual void Cleanup()
        {
            MessengerInstance.Unregister(this);
        }

        /// <summary>
        /// Broadcasts a PropertyChangedMessage using either the instance of
        /// the Messenger that was passed to this class (if available) 
        /// or the Messenger's default instance.
        /// </summary>
        /// <typeparam name="T">The type of the property that
        /// changed.</typeparam>
        /// <param name="oldValue">The value of the property before it
        /// changed.</param>
        /// <param name="newValue">The value of the property after it
        /// changed.</param>
        /// <param name="propertyName">The name of the property that
        /// changed.</param>
        protected virtual void Broadcast<T>(T oldValue, T newValue, string propertyName)
        {
            var message = new PropertyChangedMessage<T>(this, oldValue, newValue, propertyName);
            MessengerInstance.Send(message);
        }

        /// <summary>
        /// Raises the PropertyChanged event if needed, and broadcasts a
        /// PropertyChangedMessage using the Messenger instance (or the
        /// static default instance if no Messenger instance is available).
        /// </summary>
        /// <typeparam name="T">The type of the property that
        /// changed.</typeparam>
        /// <param name="propertyName">The name of the property that
        /// changed.</param>
        /// <param name="oldValue">The property's value before the change
        /// occurred.</param>
        /// <param name="newValue">The property's value after the change
        /// occurred.</param>
        /// <param name="broadcast">If true, a PropertyChangedMessage will
        /// be broadcasted. If false, only the event will be raised.</param>
        /// <remarks>If the propertyName parameter
        /// does not correspond to an existing property on the current class, an
        /// exception is thrown in DEBUG configuration only.</remarks>
        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "This cannot be an event")]
        protected virtual void RaisePropertyChanged<T>(string propertyName, T oldValue, T newValue, bool broadcast)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentException("This method cannot be called with an empty string", "propertyName");
            }

            RaisePropertyChanged(propertyName);

            if (broadcast)
            {
                Broadcast(oldValue, newValue, propertyName);
            }
        }

        /// <summary>
        /// Raises the PropertyChanged event if needed, and broadcasts a
        /// PropertyChangedMessage using the Messenger instance (or the
        /// static default instance if no Messenger instance is available).
        /// </summary>
        /// <typeparam name="T">The type of the property that
        /// changed.</typeparam>
        /// <param name="propertyExpression">An expression identifying the property
        /// that changed.</param>
        /// <param name="oldValue">The property's value before the change
        /// occurred.</param>
        /// <param name="newValue">The property's value after the change
        /// occurred.</param>
        /// <param name="broadcast">If true, a PropertyChangedMessage will
        /// be broadcasted. If false, only the event will be raised.</param>
        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "This cannot be an event")]
        [SuppressMessage("Microsoft.Design", "CA1006:GenericMethodsShouldProvideTypeParameter", Justification = "This syntax is more convenient than other alternatives.")]
        protected virtual void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression, T oldValue, T newValue, bool broadcast)
        {
            var handler = PropertyChangedHandler;

            if (handler != null
                || broadcast)
            {
                var propertyName = GetPropertyName(propertyExpression);

                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }

                if (broadcast)
                {
                    Broadcast(oldValue, newValue, propertyName);
                }
            }
        }

        /// <summary>
        /// Assigns a new value to the property. Then, raises the
        /// PropertyChanged event if needed, and broadcasts a
        /// PropertyChangedMessage using the Messenger instance (or the
        /// static default instance if no Messenger instance is available). 
        /// </summary>
        /// <typeparam name="T">The type of the property that
        /// changed.</typeparam>
        /// <param name="propertyExpression">An expression identifying the property
        /// that changed.</param>
        /// <param name="field">The field storing the property's value.</param>
        /// <param name="newValue">The property's value after the change
        /// occurred.</param>
        /// <param name="broadcast">If true, a PropertyChangedMessage will
        /// be broadcasted. If false, only the event will be raised.</param>
        [SuppressMessage("Microsoft.Design", "CA1006", Justification = "This design is better than the alternatives.")]
        [SuppressMessage("Microsoft.Design", "CA1045", Justification = "This design is better than the alternatives.")]
        protected bool Set<T>(Expression<Func<T>> propertyExpression, ref T field, T newValue, bool broadcast)
        {
            if (EqualityComparer<T>.Default.Equals(field, newValue))
            {
                return false;
            }

            RaisePropertyChanging(propertyExpression);
            var oldValue = field;
            field = newValue;
            RaisePropertyChanged(propertyExpression, oldValue, field, broadcast);
            return true;
        }

        /// <summary>
        /// Assigns a new value to the property. Then, raises the
        /// PropertyChanged event if needed, and broadcasts a
        /// PropertyChangedMessage using the Messenger instance (or the
        /// static default instance if no Messenger instance is available). 
        /// </summary>
        /// <typeparam name="T">The type of the property that
        /// changed.</typeparam>
        /// <param name="propertyName">The name of the property that
        /// changed.</param>
        /// <param name="field">The field storing the property's value.</param>
        /// <param name="newValue">The property's value after the change
        /// occurred.</param>
        /// <param name="broadcast">If true, a PropertyChangedMessage will
        /// be broadcasted. If false, only the event will be raised.</param>
        [SuppressMessage("Microsoft.Design", "CA1045", Justification = "This design is better than the alternatives.")]
        protected bool Set<T>(string propertyName, ref T field, T newValue, bool broadcast)
        {
            if (EqualityComparer<T>.Default.Equals(field, newValue))
            {
                return false;
            }

            RaisePropertyChanging(propertyName);
            var oldValue = field;
            field = newValue;
            RaisePropertyChanged(propertyName, oldValue, field, broadcast);
            return true;
        }
    }
}

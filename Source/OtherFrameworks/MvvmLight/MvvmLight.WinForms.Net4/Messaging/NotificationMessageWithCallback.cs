﻿// ****************************************************************************
// <copyright file="NotificationMessageWithCallback.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009-2012
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>29.11.2009</date>
// <project>GalaSoft.MvvmLight</project>
// <web>http://www.galasoft.ch</web>
// <license>
// See license.txt in this solution or http://www.galasoft.ch/license_MIT.txt
// </license>
// ****************************************************************************

using System;

////using GalaSoft.Utilities.Attributes;

namespace MvvmFx.MvvmLight.Messaging
{
    /// <summary>
    /// Provides a message class with a built-in callback. When the recipient
    /// is done processing the message, it can execute the callback to
    /// notify the sender that it is done. Use the <see cref="Execute" />
    /// method to execute the callback. The callback method has one parameter.
    /// <seealso cref="NotificationMessageAction"/> and
    /// <seealso cref="NotificationMessageAction&lt;TCallbackParameter&gt;"/>.
    /// </summary>
    public class NotificationMessageWithCallback : NotificationMessage
    {
        private readonly Delegate _callback;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationMessageWithCallback" /> class.
        /// </summary>
        /// <param name="notification">An arbitrary string that will be
        /// carried by the message.</param>
        /// <param name="callback">The callback method that can be executed
        /// by the recipient to notify the sender that the message has been
        /// processed.</param>
        public NotificationMessageWithCallback(string notification, Delegate callback)
            : base(notification)
        {
            CheckCallback(callback);
            _callback = callback;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationMessageWithCallback" /> class.
        /// </summary>
        /// <param name="sender">The message's sender.</param>
        /// <param name="notification">An arbitrary string that will be
        /// carried by the message.</param>
        /// <param name="callback">The callback method that can be executed
        /// by the recipient to notify the sender that the message has been
        /// processed.</param>
        public NotificationMessageWithCallback(object sender, string notification, Delegate callback)
            : base(sender, notification)
        {
            CheckCallback(callback);
            _callback = callback;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationMessageWithCallback" /> class.
        /// </summary>
        /// <param name="sender">The message's sender.</param>
        /// <param name="target">The message's intended target. This parameter can be used
        /// to give an indication as to whom the message was intended for. Of course
        /// this is only an indication, amd may be null.</param>
        /// <param name="notification">An arbitrary string that will be
        /// carried by the message.</param>
        /// <param name="callback">The callback method that can be executed
        /// by the recipient to notify the sender that the message has been
        /// processed.</param>
        public NotificationMessageWithCallback(object sender, object target, string notification, Delegate callback)
            : base(sender, target, notification)
        {
            CheckCallback(callback);
            _callback = callback;
        }

        /// <summary>
        /// Executes the callback that was provided with the message with an
        /// arbitrary number of parameters.
        /// </summary>
        /// <param name="arguments">A  number of parameters that will
        /// be passed to the callback method.</param>
        /// <returns>The object returned by the callback method.</returns>
        public virtual object Execute(params object[] arguments)
        {
            return _callback.DynamicInvoke(arguments);
        }

        private static void CheckCallback(Delegate callback)
        {
            if (callback == null)
            {
                throw new ArgumentNullException("callback", "Callback may not be null");
            }
        }
    }
}
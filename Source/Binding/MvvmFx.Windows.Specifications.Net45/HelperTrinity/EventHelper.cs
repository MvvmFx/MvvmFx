using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Kent.Boogaart.HelperTrinity
{
	/// <summary>
	/// Provides helper methods for raising events.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>EventHelper</c> class provides methods that can be used to raise events. It avoids the need for explicitly
	/// checking event sinks for <see langword="null"/> before raising the event.
	/// </para>
	/// </remarks>
	/// <example>
	/// The following example shows how a non-generic event can be raised:
	/// <code>
	/// internal event EventHandler Changed;
	///
	/// protected void OnChanged()
	/// {
	///		EventHelper.Raise(Changed, this);
	/// }
	/// </code>
	/// </example>
	/// <example>
	/// The following example shows how a non-generic event can be raised where the event type requires a specific
	/// <c>EventArgs</c> subclass:
	/// <code>
	/// internal event PropertyChangedEventHandler PropertyChanged;
	///
	/// protected void OnPropertyChanged(PropertyChangedEventArgs e)
	/// {
	///		EventHelper.Raise(PropertyChanged, this, e);
	/// }
	/// </code>
	/// </example>
	/// <example>
	/// The following example shows how a generic event can be raised:
	/// <code>
	/// internal event EventHandler&lt;EventArgs&gt; Changed;
	///
	/// protected void OnChanged()
	/// {
	///		EventHelper.Raise(Changed, this, EventArgs.Empty);
	/// }
	/// </code>
	/// </example>
	/// <example>
	/// The following example shows how a generic event with custom event arguments can be raised:
	/// <code>
	/// internal event EventHandler&lt;MyEventArgs&gt; MyEvent;
	///
	/// protected void OnMyEvent(MyEventArgs e)
	/// {
	///		EventHelper.Raise(MyEventArgs, this, e);
	/// }
	/// </code>
	/// </example>
	/// <example>
	/// The following example raises a generic event, but does not create the event arguments unless there is at least one
	/// handler for the event:
	/// <code>
	/// internal event EventHandler&lt;MyEventArgs&gt; MyEvent;
	///
	/// protected void OnMyEvent(int someData)
	/// {
	///		EventHelper.Raise(MyEvent, this, delegate
	///		{
	///			return new MyEventArgs(someData);
	///		});
	/// }
	/// </code>
	/// </example>
	internal static class EventHelper
	{
		[SuppressMessage("Microsoft.Design", "CA1030", Justification = "False positive - the Raise method overloads are supposed to raise an event on behalf of a client, not on behalf of its declaring class.")]
		[DebuggerHidden]
		internal static void BeginRaise(EventHandler handler, object sender, AsyncCallback callback, object asyncState)
		{
			if (handler != null)
			{
#if DEBUG
				BeginRaiseWithDiagnostics(handler, callback, asyncState, sender, EventArgs.Empty);
#else
				new Raise_EventHandler_Object_Handler(Raise).BeginInvoke(handler, sender, callback, asyncState);
#endif
			}
		}

		private delegate void Raise_EventHandler_Object_Handler(EventHandler hander, object sender);

		[SuppressMessage("Microsoft.Design", "CA1030", Justification = "False positive - the Raise method overloads are supposed to raise an event on behalf of a client, not on behalf of its declaring class.")]
		[DebuggerHidden]
		internal static void Raise(EventHandler handler, object sender)
		{
			if (handler != null)
			{
#if DEBUG
				RaiseWithDiagnostics(handler, sender, EventArgs.Empty);
#else
				handler(sender, EventArgs.Empty);
#endif
			}
		}

		[SuppressMessage("Microsoft.Design", "CA1030", Justification = "False positive - the Raise method overloads are supposed to raise an event on behalf of a client, not on behalf of its declaring class.")]
		[DebuggerHidden]
		internal static void BeginRaise(Delegate handler, object sender, EventArgs e, AsyncCallback callback, object asyncState)
		{
			if (handler != null)
			{
#if DEBUG
				BeginRaiseWithDiagnostics(handler, callback, asyncState, sender, e);
#else
				new Raise_Delegate_Object_EventArgs_Handler(Raise).BeginInvoke(handler, sender, e, callback, asyncState);
#endif
			}
		}

		private delegate void Raise_Delegate_Object_EventArgs_Handler(Delegate handler, object sender, EventArgs e);

		[SuppressMessage("Microsoft.Design", "CA1030", Justification = "False positive - the Raise method overloads are supposed to raise an event on behalf of a client, not on behalf of its declaring class.")]
		[DebuggerHidden]
		internal static void Raise(Delegate handler, object sender, EventArgs e)
		{
			if (handler != null)
			{
#if DEBUG
				RaiseWithDiagnostics(handler, sender, e);
#else
				handler.DynamicInvoke(sender, e);
#endif
			}
		}

		[SuppressMessage("Microsoft.Design", "CA1030", Justification = "False positive - the Raise method overloads are supposed to raise an event on behalf of a client, not on behalf of its declaring class.")]
		[DebuggerHidden]
		internal static void BeginRaise<T>(EventHandler<T> handler, object sender, T e, AsyncCallback callback, object asyncState)
			where T : EventArgs
		{
			if (handler != null)
			{
#if DEBUG
				BeginRaiseWithDiagnostics(handler, callback, asyncState, sender, e);
#else
				new Raise_GenericEventHandler_Object_EventArgs_Handler<T>(Raise).BeginInvoke(handler, sender, e, callback, asyncState);
#endif
			}
		}

		private delegate void Raise_GenericEventHandler_Object_EventArgs_Handler<T>(EventHandler<T> handler, object sender, T e)
			where T : EventArgs;

		[SuppressMessage("Microsoft.Design", "CA1030", Justification = "False positive - the Raise method overloads are supposed to raise an event on behalf of a client, not on behalf of its declaring class.")]
		[DebuggerHidden]
		internal static void Raise<T>(EventHandler<T> handler, object sender, T e)
			where T : EventArgs
		{
			if (handler != null)
			{
#if DEBUG
				RaiseWithDiagnostics(handler, sender, e);
#else
				handler(sender, e);
#endif
			}
		}

		[SuppressMessage("Microsoft.Design", "CA1030", Justification = "False positive - the Raise method overloads are supposed to raise an event on behalf of a client, not on behalf of its declaring class.")]
		[DebuggerHidden]
		internal static void BeginRaise<T>(EventHandler<T> handler, object sender, CreateEventArguments<T> createEventArguments, AsyncCallback callback, object asyncState)
			where T : EventArgs
		{
			ArgumentHelper.AssertNotNull(createEventArguments, "createEventArguments");

			if (handler != null)
			{
#if DEBUG
				BeginRaiseWithDiagnostics(handler, callback, asyncState, sender, createEventArguments());
#else
				new Raise_GenericEventHandler_Object_GenericCreateEventArguments_Handler<T>(Raise).BeginInvoke(handler, sender, createEventArguments, callback, asyncState);
#endif
			}
		}

		private delegate void Raise_GenericEventHandler_Object_GenericCreateEventArguments_Handler<T>(EventHandler<T> handler, object sender, CreateEventArguments<T> createEventArguments)
			where T : EventArgs;

		[SuppressMessage("Microsoft.Design", "CA1030", Justification = "False positive - the Raise method overloads are supposed to raise an event on behalf of a client, not on behalf of its declaring class.")]
		[DebuggerHidden]
		internal static void Raise<T>(EventHandler<T> handler, object sender, CreateEventArguments<T> createEventArguments)
			where T : EventArgs
		{
			ArgumentHelper.AssertNotNull(createEventArguments, "createEventArguments");

			if (handler != null)
			{
#if DEBUG
				RaiseWithDiagnostics(handler, sender, createEventArguments());
#else
				handler(sender, createEventArguments());
#endif
			}
		}

#if DEBUG
		private delegate void RaiseWithDiagnosticsHandler(Delegate handler, params object[] parameters);

		private static void BeginRaiseWithDiagnostics(Delegate handler, AsyncCallback callback, object asyncState, params object[] parameters)
		{
			new RaiseWithDiagnosticsHandler(RaiseWithDiagnostics).BeginInvoke(handler, parameters, callback, asyncState);
		}

		/// <summary>
		/// A method used by debug builds to raise events and log diagnostic information in the process.
		/// </summary>
		/// <remarks>
		/// This method is only called in debug builds. It logs details about raised events and any exceptions thrown by event
		/// handlers.
		/// </remarks>
		/// <param name="handler">
		/// The event handler.
		/// </param>
		/// <param name="parameters">
		/// Parameters to the event handler.
		/// </param>
		private static void RaiseWithDiagnostics(Delegate handler, params object[] parameters)
		{
			Debug.Assert(handler != null);
			//var threadName = System.Threading.Thread.CurrentThread.Name;
			//Debug.WriteLine(string.Format("Event being raised by thread '{0}'.", threadName));

			foreach (var del in handler.GetInvocationList())
			{
				try
				{
					//Debug.WriteLine(string.Format("   Calling method '{0}.{1}'.", del.Method.DeclaringType.FullName, del.Method.Name));
					del.DynamicInvoke(parameters);
				}
				catch (Exception ex)
				{
					var sb = new StringBuilder();
					sb.AppendLine("   An exception occurred in the event handler:");

					while (ex != null)
					{
						sb.Append("   ").AppendLine(ex.Message);
						sb.AppendLine(ex.StackTrace);
						ex = ex.InnerException;

						if (ex != null)
						{
							sb.AppendLine("--- INNER EXCEPTION ---");
						}
					}

					Debug.WriteLine(sb.ToString());

					//the exception isn't swallowed - just logged
					throw;
				}
			}

			//Debug.WriteLine(string.Format("Finished raising event by thread '{0}'.", threadName));
		}
#endif

		/// <summary>
		/// A handler used to create an event arguments instance for the
		/// <see cref="Raise{T}(EventHandler{T}, object, CreateEventArguments{T})"/> method.
		/// </summary>
		/// <remarks>
		/// This delegate is invoked by the
		/// <see cref="Raise{T}(EventHandler{T}, object, CreateEventArguments{T})"/> method to create the
		/// event arguments instance. The handler should create the instance and return it.
		/// </remarks>
		/// <typeparam name="T">
		/// The event arguments type.
		/// </typeparam>
		/// <returns>
		/// The event arguments instance.
		/// </returns>
		internal delegate T CreateEventArguments<T>()
			where T : EventArgs;
	}
}

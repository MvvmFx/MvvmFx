using System;
using System.Diagnostics;

namespace Kent.Boogaart.HelperTrinity.Extensions
{
	/// <summary>
	/// Defines extension methods for the <see cref="EventHelper"/> class.
	/// </summary>
	/// <remarks>
	/// This class defines extensions methods for the <see cref="EventHelper"/>. All extension methods simply delegate to the
	/// appropriate member of the <see cref="EventHelper"/> class.
	/// </remarks>
	internal static class EventHelperExtensions
	{
		[DebuggerHidden]
		internal static void BeginRaise(this EventHandler handler, object sender, AsyncCallback callback, object asyncState)
		{
			EventHelper.BeginRaise(handler, sender, callback, asyncState);
		}

		[DebuggerHidden]
		internal static void Raise(this EventHandler handler, object sender)
		{
			EventHelper.Raise(handler, sender);
		}

		[DebuggerHidden]
		internal static void BeginRaise(this Delegate handler, object sender, EventArgs e, AsyncCallback callback, object asyncState)
		{
			EventHelper.BeginRaise(handler, sender, e, callback, asyncState);
		}

		[DebuggerHidden]
		internal static void Raise(this Delegate handler, object sender, EventArgs e)
		{
			EventHelper.Raise(handler, sender, e);
		}

		[DebuggerHidden]
		internal static void BeginRaise<T>(this EventHandler<T> handler, object sender, T e, AsyncCallback callback, object asyncState)
			where T : EventArgs
		{
			EventHelper.BeginRaise(handler, sender, e, callback, asyncState);
		}

		[DebuggerHidden]
		internal static void Raise<T>(this EventHandler<T> handler, object sender, T e)
			where T : EventArgs
		{
			EventHelper.Raise(handler, sender, e);
		}

		[DebuggerHidden]
		internal static void BeginRaise<T>(this EventHandler<T> handler, object sender, Kent.Boogaart.HelperTrinity.EventHelper.CreateEventArguments<T> createEventArguments, AsyncCallback callback, object asyncState)
			where T : EventArgs
		{
			EventHelper.BeginRaise(handler, sender, createEventArguments, callback, asyncState);
		}

		[DebuggerHidden]
		internal static void Raise<T>(this EventHandler<T> handler, object sender, Kent.Boogaart.HelperTrinity.EventHelper.CreateEventArguments<T> createEventArguments)
			where T : EventArgs
		{
			EventHelper.Raise(handler, sender, createEventArguments);
		}
	}
}
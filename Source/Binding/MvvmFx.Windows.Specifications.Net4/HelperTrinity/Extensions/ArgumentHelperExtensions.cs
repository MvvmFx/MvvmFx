using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Kent.Boogaart.HelperTrinity.Extensions
{
	/// <summary>
	/// Defines extension methods for the <see cref="ArgumentHelper"/> class.
	/// </summary>
	/// <remarks>
	/// This class defines extensions methods for the <see cref="ArgumentHelper"/>. All extension methods simply delegate to the
	/// appropriate member of the <see cref="ArgumentHelper"/> class.
	/// </remarks>
	internal static class ArgumentHelperExtensions
	{
		[DebuggerHidden]
		internal static void AssertNotNull<T>(this T arg, string argName)
			where T : class
		{
			ArgumentHelper.AssertNotNull(arg, argName);
		}

		[DebuggerHidden]
		internal static void AssertNotNull<T>(this Nullable<T> arg, string argName)
			where T : struct
		{
			ArgumentHelper.AssertNotNull(arg, argName);
		}

		[DebuggerHidden]
		internal static void AssertGenericArgumentNotNull<T>(this T arg, string argName)
		{
			ArgumentHelper.AssertGenericArgumentNotNull(arg, argName);
		}

		[DebuggerHidden]
		internal static void AssertNotNull<T>(this IEnumerable<T> arg, string argName, bool assertContentsNotNull)
		{
			ArgumentHelper.AssertNotNull(arg, argName, assertContentsNotNull);
		}

		[DebuggerHidden]
		internal static void AssertNotNullOrEmpty(this string arg, string argName)
		{
			ArgumentHelper.AssertNotNullOrEmpty(arg, argName);
		}

		[DebuggerHidden]
		internal static void AssertNotNullOrEmpty(this string arg, string argName, bool trim)
		{
			ArgumentHelper.AssertNotNullOrEmpty(arg, argName, trim);
		}

		[DebuggerHidden]
//		[CLSCompliant(false)]
		internal static void AssertEnumMember<TEnum>(this TEnum enumValue, string argName)
			where TEnum : struct, IConvertible
		{
			ArgumentHelper.AssertEnumMember(enumValue, argName);
		}

		[DebuggerHidden]
//		[CLSCompliant(false)]
		internal static void AssertEnumMember<TEnum>(this TEnum enumValue, string argName, params TEnum[] validValues)
			where TEnum : struct, IConvertible
		{
			ArgumentHelper.AssertEnumMember(enumValue, argName, validValues);
		}
	}
}
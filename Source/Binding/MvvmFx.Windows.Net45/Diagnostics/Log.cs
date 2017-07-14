using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace MvvmFx.Windows.Diagnostics
{
    /// <summary>
    ///Provides functionality for making log entries.
    /// </summary>
    internal static class Log
    {
        private static readonly TraceSource TraceSource = new TraceSource("MvvmFx.Windows");
        private const TraceEventType PerformanceEventType = TraceEventType.Information;

        [SuppressMessage("Microsoft.Performance", "CA1811", Justification = "Method of infrastructure class. May be needed at developer's discretion.")]
        public static bool IsEnabled(TraceEventType eventType)
        {
            return TraceSource.Switch.ShouldTrace(eventType);
        }

        public static void Write(TraceEventType eventType, string message)
        {
            TraceSource.TraceEvent(eventType, 0, message);
        }

        [SuppressMessage("Microsoft.Performance", "CA1811", Justification = "Method of infrastructure class. May be needed at developer's discretion.")]
        public static void Write(TraceEventType eventType, int eventId, string message)
        {
            TraceSource.TraceEvent(eventType, eventId, message);
        }

        public static void Write(TraceEventType eventType, string format, params object[] args)
        {
            TraceSource.TraceEvent(eventType, 0, format, args);
        }

        [SuppressMessage("Microsoft.Performance", "CA1811", Justification = "Method of infrastructure class. May be needed at developer's discretion.")]
        public static void Write(TraceEventType eventType, int eventId, string format, params object[] args)
        {
            TraceSource.TraceEvent(eventType, eventId, format, args);
        }

        [SuppressMessage("Microsoft.Performance", "CA1811", Justification = "Method of infrastructure class. May be needed at developer's discretion.")]
        public static void WriteData(TraceEventType eventType, params object[] data)
        {
            TraceSource.TraceData(eventType, 0, data);
        }

        [SuppressMessage("Microsoft.Performance", "CA1811", Justification = "Method of infrastructure class. May be needed at developer's discretion.")]
        public static void WriteData(TraceEventType eventType, int eventId, params object[] data)
        {
            TraceSource.TraceData(eventType, eventId, data);
        }

        [SuppressMessage("Microsoft.Performance", "CA1811", Justification = "Method of infrastructure class. May be needed at developer's discretion.")]
        public static IDisposable Performance(string message)
        {
            if (!IsEnabled(PerformanceEventType))
            {
                return DummyPerformanceEntry.Instance;
            }

            return new PerformanceEntry(message);
        }

        [SuppressMessage("Microsoft.Performance", "CA1811", Justification = "Method of infrastructure class. May be needed at developer's discretion.")]
        public static IDisposable Performance(string format, params object[] args)
        {
            return Performance(string.Format(CultureInfo.InvariantCulture, format, args));
        }

        /// <summary>
        /// Used when performance logging is turned off, to increase performance.
        /// </summary>
        private sealed class DummyPerformanceEntry : IDisposable
        {
            public static readonly IDisposable Instance = new DummyPerformanceEntry();

            private DummyPerformanceEntry()
            {
            }

            public void Dispose()
            {
            }
        }

        /// <summary>
        /// Used when performance logging is turned on.
        /// </summary>
        private sealed class PerformanceEntry : IDisposable
        {
            private readonly string _message;
            private readonly Stopwatch _stopwatch;
            private bool _disposed;

            [SuppressMessage("Microsoft.Performance", "CA1811", Justification = "Method of infrastructure class. May be needed at developer's discretion.")]
            public PerformanceEntry(string message)
            {
                _message = message;
                _stopwatch = Stopwatch.StartNew();
            }

            public void Dispose()
            {
                if (!_disposed)
                {
                    Write(PerformanceEventType,
                          "Performance for '{0}': {1} ({2} ms)",
                          _message,
                          _stopwatch.Elapsed,
                          _stopwatch.ElapsedMilliseconds);
                    _disposed = true;
                }
            }
        }
    }
}

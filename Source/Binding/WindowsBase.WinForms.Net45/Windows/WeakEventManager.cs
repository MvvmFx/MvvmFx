//
// WeakEventManager.cs
//
// Author:
//   Chris Toshok (toshok@ximian.com)
//
// (C) 2007 Novell, Inc.
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace MvvmFx.Bindings
{
    /// <summary>
    /// WeakEventManager
    /// </summary>
    /// <remarks>This class isn't completely implemented.</remarks>
    public abstract class WeakEventManager
    {
        private Hashtable sourceData;

        protected WeakEventManager()
        {
            sourceData = new Hashtable();
        }

        [SuppressMessage("Microsoft.Design", "CA1065", Justification = "The feature isn't implemented.")]
        [SuppressMessage("Microsoft.Performance", "CA1822", Justification = "The feature isn't implemented.")]
        protected IDisposable ReadLock
        {
            get { throw new NotImplementedException("WeakEventManager"); }
        }

        [SuppressMessage("Microsoft.Design", "CA1065", Justification = "The feature isn't implemented.")]
        [SuppressMessage("Microsoft.Performance", "CA1822", Justification = "The feature isn't implemented.")]
        protected IDisposable WriteLock
        {
            get { throw new NotImplementedException("WeakEventManager"); }
        }

        protected object this[object source]
        {
            get { return sourceData[source]; }
            set { sourceData[source] = value; }
        }

        protected void DeliverEvent(object sender, EventArgs args)
        {
            DeliverEventToList(sender, args, (ListenerList) this[sender]);
        }

        protected void DeliverEventToList(object sender, EventArgs args, ListenerList list)
        {
            if (list == null)
                throw new ArgumentNullException("list");

            for (int i = 0; i < list.Count; i++)
            {
                IWeakEventListener listener = list[i];
                listener.ReceiveWeakEvent(GetType(), sender, args);
            }
        }

        protected void ProtectedAddListener(object source, IWeakEventListener listener)
        {
            ListenerList list = sourceData[source] as ListenerList;
            if (list != null)
                list.Add(listener);
        }

        protected void ProtectedRemoveListener(object source, IWeakEventListener listener)
        {
            ListenerList list = sourceData[source] as ListenerList;
            if (list != null)
                list.Remove(listener);
        }

        protected virtual bool Purge(object source, object data, bool purgeAll)
        {
            throw new NotImplementedException("WeakEventManager");
        }

        [SuppressMessage("Microsoft.Design", "CA1065", Justification = "The feature isn't implemented.")]
        [SuppressMessage("Microsoft.Usage", "CA1801", Justification = "The feature isn't implemented.")]
        [SuppressMessage("Microsoft.Performance", "CA1822", Justification = "The feature isn't implemented.")]
        protected void Remove(object source)
        {
            throw new NotImplementedException("WeakEventManager.Purge");
        }

        [SuppressMessage("Microsoft.Performance", "CA1822", Justification = "The feature isn't implemented.")]
        protected void ScheduleCleanup()
        {
            throw new NotImplementedException("WeakEventManager.ScheduleCleanup");
        }

        protected abstract void StartListening(object source);

        protected abstract void StopListening(object source);

        [SuppressMessage("Microsoft.Usage", "CA1801", Justification = "The feature isn't implemented.")]
        protected static WeakEventManager GetCurrentManager(Type managerType)
        {
            throw new NotImplementedException("WeakEventManager.GetCurrentManager");
        }

        [SuppressMessage("Microsoft.Usage", "CA1801", Justification = "The feature isn't implemented.")]
        protected static void SetCurrentManager(Type managerType, WeakEventManager manager)
        {
            throw new NotImplementedException("WeakEventManager.SetCurrentManager");
        }

        #region protected ListenerList class

        /// <summary>
        /// ListenerList
        /// </summary>
        /// <remarks>This class isn't implemented.</remarks>
        protected class ListenerList
        {
            public ListenerList()
            {
                throw new NotImplementedException("ListenerList");
            }

            [SuppressMessage("Microsoft.Usage", "CA1801", Justification = "The feature isn't implemented.")]
            public ListenerList(int capacity)
            {
                throw new NotImplementedException("ListenerList");
            }

            [SuppressMessage("Microsoft.Design", "CA1065", Justification = "The feature isn't implemented.")]
            [SuppressMessage("Microsoft.Performance", "CA1822", Justification = "The feature isn't implemented.")]
            public int Count
            {
                get { throw new NotImplementedException("ListenerList"); }
            }

            [SuppressMessage("Microsoft.Design", "CA1065", Justification = "The feature isn't implemented.")]
            public static ListenerList Empty
            {
                get { throw new NotImplementedException("ListenerList"); }
            }

            [SuppressMessage("Microsoft.Design", "CA1065", Justification = "The feature isn't implemented.")]
            [SuppressMessage("Microsoft.Performance", "CA1822", Justification = "The feature isn't implemented.")]
            public bool IsEmpty
            {
                get { throw new NotImplementedException("ListenerList"); }
            }

            [SuppressMessage("Microsoft.Design", "CA1065", Justification = "The feature isn't implemented.")]
            [SuppressMessage("Microsoft.Usage", "CA1801", Justification = "The feature isn't implemented.")]
            [SuppressMessage("Microsoft.Performance", "CA1822", Justification = "The feature isn't implemented.")]
            public IWeakEventListener this[int index]
            {
                get { throw new NotImplementedException("ListenerList"); }
            }

            [SuppressMessage("Microsoft.Usage", "CA1801", Justification = "The feature isn't implemented.")]
            [SuppressMessage("Microsoft.Performance", "CA1822", Justification = "The feature isn't implemented.")]
            public void Add(IWeakEventListener listener)
            {
                throw new NotImplementedException("ListenerList");
            }

            [SuppressMessage("Microsoft.Performance", "CA1822", Justification = "The feature isn't implemented.")]
            public bool BeginUse()
            {
                throw new NotImplementedException("ListenerList");
            }

            [SuppressMessage("Microsoft.Performance", "CA1822", Justification = "The feature isn't implemented.")]
            public WeakEventManager.ListenerList Clone()
            {
                throw new NotImplementedException("ListenerList");
            }

            [SuppressMessage("Microsoft.Performance", "CA1822", Justification = "The feature isn't implemented.")]
            public void EndUse()
            {
                throw new NotImplementedException("ListenerList");
            }

            [SuppressMessage("Microsoft.Usage", "CA1801", Justification = "The feature isn't implemented.")]
            [SuppressMessage("Microsoft.Design", "CA1045", Justification = "Signature compatibility.")]
            public static bool PrepareForWriting(ref WeakEventManager.ListenerList list)
            {
                throw new NotImplementedException("ListenerList");
            }

            [SuppressMessage("Microsoft.Performance", "CA1822", Justification = "The feature isn't implemented.")]
            public bool Purge()
            {
                throw new NotImplementedException("ListenerList");
            }

            [SuppressMessage("Microsoft.Usage", "CA1801", Justification = "The feature isn't implemented.")]
            [SuppressMessage("Microsoft.Performance", "CA1822", Justification = "The feature isn't implemented.")]
            public void Remove(IWeakEventListener listener)
            {
                throw new NotImplementedException("ListenerList");
            }
        }

        #endregion
    }
}

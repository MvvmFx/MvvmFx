/*
Original code
  from WPF Application Framework (WAF)
 http://waf.codeplex.com/

Microsoft Public License (Ms-PL)

This license governs use of the accompanying software. If you use the software, you accept this license. If you do not accept the license, do not use the software.

1. Definitions
The terms "reproduce," "reproduction," "derivative works," and "distribution" have the same meaning here as under U.S. copyright law.
A "contribution" is the original software, or any additions or changes to the software.
A "contributor" is any person that distributes its contribution under this license.
"Licensed patents" are a contributor's patent claims that read directly on its contribution.

2. Grant of Rights
(A) Copyright Grant- Subject to the terms of this license, including the license conditions and limitations in section 3, each contributor grants you a non-exclusive, worldwide, royalty-free copyright license to reproduce its contribution, prepare derivative works of its contribution, and distribute its contribution or any derivative works that you create.
(B) Patent Grant- Subject to the terms of this license, including the license conditions and limitations in section 3, each contributor grants you a non-exclusive, worldwide, royalty-free license under its licensed patents to make, have made, use, sell, offer for sale, import, and/or otherwise dispose of its contribution in the software or derivative works of the contribution in the software.

3. Conditions and Limitations
(A) No Trademark License- This license does not grant you rights to use any contributors' name, logo, or trademarks.
(B) If you bring a patent claim against any contributor over patents that you claim are infringed by the software, your patent license from such contributor to the software ends automatically.
(C) If you distribute any portion of the software, you must retain all copyright, patent, trademark, and attribution notices that are present in the software.
(D) If you distribute any portion of the software in source code form, you may do so only under this license by including a complete copy of this license with your distribution. If you distribute any portion of the software in compiled or object code form, you may only do so under a license that complies with this license.
(E) The software is licensed "as-is." You bear the risk of using it. The contributors give no express warranties, guarantees or conditions. You may have additional consumer rights under your local laws which this license cannot change. To the extent permitted under your local laws, the contributors exclude the implied warranties of merchantability, fitness for a particular purpose and non-infringement.
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using MvvmFx.Windows.Properties;

namespace MvvmFx.Windows.Data
{
    /// <summary>
    /// Generic IBindingList implementation that can be instantiated with reference type T.
    /// </summary>
    /// <typeparam name="T">The item type of the list.</typeparam>
    [SuppressMessage("Microsoft.Naming", "CA1710", Justification = "'Adapter' is a well know stereotype.")]
    public sealed class BindingListAdapter<T> : IList<T>, IBindingList
    {
        private readonly IList<T> _innerList;
        private readonly INotifyCollectionChanged _innerNotificationProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="BindingListAdapter&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="list">The list.</param>
        [SuppressMessage("Microsoft.Performance", "CA1800", Justification = "'_innerList' is casted once to two different and alternative types.")]
        public BindingListAdapter(object list)
        {
            if (list == null)
                throw new ArgumentNullException("list");

            if (list is IList<T>)
            {
                _innerList = (IList<T>) list;
            }
            else if (list is IEnumerable<T>)
            {
                _innerList = new ReadOnlyCollection<T>(((IEnumerable<T>) list).ToList());
            }
            else
            {
                throw new ArgumentException(Resources.ArgumentMustBeCollection, "list");
            }

            _innerNotificationProvider = list as INotifyCollectionChanged;
            if (_innerNotificationProvider != null)
            {
                _innerNotificationProvider.CollectionChanged += InnerCollectionChanged;
                foreach (object item in _innerList)
                {
                    StartListeningToPropertyChanged(item);
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is read only.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is read only; otherwise, <c>false</c>.
        /// </value>
        public bool IsReadOnly
        {
            get { return _innerList.IsReadOnly; }
        }

        /// <summary>
        /// Gets the number of elements contained in this instance.
        /// </summary>
        public int Count
        {
            get { return _innerList.Count; }
        }

        /// <summary>
        /// Gets or sets the element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get or set.</param>
        /// <returns>The element at the specified index.</returns>
        public T this[int index]
        {
            get { return _innerList[index]; }
            set { _innerList[index] = value; }
        }

        /// <summary>
        /// Gets a value indicating whether access to the <see cref="T:System.Collections.ICollection"/> is synchronized (thread safe).
        /// </summary>
        /// <returns> <c>true</c> if access to the <see cref="T:System.Collections.ICollection"/> is synchronized (thread safe); otherwise, <c>false</c>.</returns>
        bool ICollection.IsSynchronized
        {
            get { return false; }
        }

        /// <summary>
        /// Gets an object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection"/>.
        /// </summary>
        /// <returns>An object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection"/>.</returns>
        object ICollection.SyncRoot
        {
            get { return null; }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Collections.IList"/> has a fixed size.
        /// </summary>
        /// <returns> <c>true</c> if the <see cref="T:System.Collections.IList"/> has a fixed size; otherwise, <c>false</c>.</returns>
        bool IList.IsFixedSize
        {
            get { return false; }
        }

        /// <summary>
        /// Gets or sets the element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get or set.</param>
        /// <returns>The element at the specified index.</returns>
        object IList.this[int index]
        {
            get { return _innerList[index]; }
            set { _innerList[index] = (T) value; }
        }

        /// <summary>
        /// Gets whether you can add items to the list using <see cref="M:System.ComponentModel.IBindingList.AddNew"/>.
        /// </summary>
        /// <returns>
        /// <c>true</c> if you can add items to the list using <see cref="M:System.ComponentModel.IBindingList.AddNew"/>; otherwise, <c>false</c>.</returns>
        bool IBindingList.AllowNew
        {
            get { return false; }
        }

        /// <summary>
        /// Gets whether you can update items in the list.
        /// </summary>
        /// <returns>
        /// <c>true</c> if you can update the items in the list; otherwise, <c>false</c>.</returns>
        bool IBindingList.AllowEdit
        {
            get { return true; }
        }

        /// <summary>
        /// Gets whether you can remove items from the list, using <see cref="M:System.Collections.IList.Remove(System.Object)"/> or <see cref="M:System.Collections.IList.RemoveAt(System.Int32)"/>.
        /// </summary>
        /// <returns>
        /// <c>true</c> if you can remove items from the list; otherwise, <c>false</c>.</returns>
        bool IBindingList.AllowRemove
        {
            get { return !IsReadOnly; }
        }

        /// <summary>
        /// Gets whether a <see cref="E:System.ComponentModel.IBindingList.ListChanged"/> event is raised when the list changes or an item in the list changes.
        /// </summary>
        /// <returns>
        /// <c>true</c> if a <see cref="E:System.ComponentModel.IBindingList.ListChanged"/> event is raised when the list changes or when an item changes; otherwise, <c>false</c>.</returns>
        bool IBindingList.SupportsChangeNotification
        {
            get { return true; }
        }

        /// <summary>
        /// Gets whether the list supports sorting.
        /// </summary>
        /// <returns>
        /// true if the list supports sorting; otherwise, false.
        /// </returns>
        bool IBindingList.SupportsSorting
        {
            get { return false; }
        }

        /// <summary>
        /// Gets whether the items in the list are sorted.
        /// </summary>
        /// <returns>
        /// <c>true</c> if <see cref="M:System.ComponentModel.IBindingList.ApplySort(System.ComponentModel.PropertyDescriptor,System.ComponentModel.ListSortDirection)"/> has been called and <see cref="M:System.ComponentModel.IBindingList.RemoveSort"/> has not been called; otherwise, <c>false</c>.</returns>
        ///
        /// <exception cref="T:System.NotSupportedException">
        ///   <see cref="P:System.ComponentModel.IBindingList.SupportsSorting"/> is false. </exception>
        bool IBindingList.IsSorted
        {
            get { return false; }
        }

        /// <summary>
        /// Gets the direction of the sort.
        /// </summary>
        /// <returns>One of the <see cref="T:System.ComponentModel.ListSortDirection"/> values.</returns>
        ///
        /// <exception cref="T:System.NotSupportedException">
        ///   <see cref="P:System.ComponentModel.IBindingList.SupportsSorting"/> is false. </exception>
        ListSortDirection IBindingList.SortDirection
        {
            get { return ListSortDirection.Ascending; }
        }

        /// <summary>
        /// Gets the <see cref="T:System.ComponentModel.PropertyDescriptor"/> that is being used for sorting.
        /// </summary>
        /// <returns>The <see cref="T:System.ComponentModel.PropertyDescriptor"/> that is being used for sorting.</returns>
        ///
        /// <exception cref="T:System.NotSupportedException">
        ///   <see cref="P:System.ComponentModel.IBindingList.SupportsSorting"/> is false. </exception>
        PropertyDescriptor IBindingList.SortProperty
        {
            get { return null; }
        }

        /// <summary>
        /// Gets whether the list supports searching using the <see cref="M:System.ComponentModel.IBindingList.Find(System.ComponentModel.PropertyDescriptor,System.Object)"/> method.
        /// </summary>
        /// <returns>
        ///     <c>true</c> if the list supports searching using the <see cref="M:System.ComponentModel.IBindingList.Find(System.ComponentModel.PropertyDescriptor,System.Object)"/> method; otherwise, <c>false</c>.</returns>
        bool IBindingList.SupportsSearching
        {
            get { return false; }
        }

        /// <summary>
        /// Occurs when the list changes or an item in the list changes.
        /// </summary>
        public event ListChangedEventHandler ListChanged;

        /// <summary>
        /// Determines whether [contains] [the specified item].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>
        ///   <c>true</c> if [contains] [the specified item]; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(T item)
        {
            return _innerList.Contains(item);
        }

        /// <summary>
        /// Determines the index of a specific item in the <see cref="T:System.Collections.Generic.IList`1"/>.
        /// </summary>
        /// <returns>
        /// The index of <paramref name="item"/> if found in the list; otherwise, -1.
        /// </returns>
        /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.IList`1"/>.</param>
        public int IndexOf(T item)
        {
            return _innerList.IndexOf(item);
        }

        /// <summary>
        /// Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param><exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.</exception>
        public void Add(T item)
        {
            _innerList.Add(item);
        }

        /// <summary>
        /// Inserts an item to the <see cref="T:System.Collections.Generic.IList`1"/> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which <paramref name="item"/> should be inserted.</param><param name="item">The object to insert into the <see cref="T:System.Collections.Generic.IList`1"/>.</param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index"/> is not a valid index in the <see cref="T:System.Collections.Generic.IList`1"/>.</exception><exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.IList`1"/> is read-only.</exception>
        public void Insert(int index, T item)
        {
            _innerList.Insert(index, item);
        }

        /// <summary>
        /// Removes the specified item.
        /// </summary>
        /// <param name="item">The object to remove from the System.Collections.Generic.ICollection&lt;T&gt;.</param>
        /// <returns>
        ///     <c>true</c>  if item was successfully removed from the System.Collections.Generic.ICollection&lt;T&gt;; otherwise, false. This method also returns false if item is not found in the original System.Collections.Generic.ICollection&lt;T&gt;.</returns>
        public bool Remove(T item)
        {
            return _innerList.Remove(item);
        }

        /// <summary>
        /// Removes the System.Collections.Generic.IList&lt;T&gt; item at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the item to remove</param>
        public void RemoveAt(int index)
        {
            _innerList.RemoveAt(index);
        }

        /// <summary>
        /// Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only. </exception>
        public void Clear()
        {
            _innerList.Clear();
        }

        /// <summary>
        /// Copies the elements of the <see cref="System.Collections.Generic.ICollection&lt;T&gt;"/> to an <see cref="System.Array"/>, starting at a particular <see cref="System.Array"/> index.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="arrayIndex">Index of the array.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            _innerList.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public IEnumerator<T> GetEnumerator()
        {
            return _innerList.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Copies the elements of the <see cref="T:System.Collections.ICollection"/> to an <see cref="T:System.Array"/>, starting at a particular <see cref="T:System.Array"/> index.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="T:System.Array"/> that is the destination of the elements copied from <see cref="T:System.Collections.ICollection"/>. The <see cref="T:System.Array"/> must have zero-based indexing.</param>
        /// <param name="index">The zero-based index in <paramref name="array"/> at which copying begins.</param>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="array"/> is null. </exception>
        ///
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///   <paramref name="index"/> is less than zero. </exception>
        ///
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="array"/> is multidimensional.-or- The number of elements in the source <see cref="T:System.Collections.ICollection"/> is greater than the available space from <paramref name="index"/> to the end of the destination <paramref name="array"/>. </exception>
        ///
        /// <exception cref="T:System.ArgumentException">The type of the source <see cref="T:System.Collections.ICollection"/> cannot be cast automatically to the type of the destination <paramref name="array"/>. </exception>
        void ICollection.CopyTo(Array array, int index)
        {
            CopyTo((T[]) array, index);
        }

        /// <summary>
        /// Determines whether the <see cref="T:System.Collections.IList"/> contains a specific value.
        /// </summary>
        /// <param name="value">The object to locate in the <see cref="T:System.Collections.IList"/>.</param>
        /// <returns>
        /// true if the <see cref="T:System.Object"/> is found in the <see cref="T:System.Collections.IList"/>; otherwise, false.
        /// </returns>
        bool IList.Contains(object value)
        {
            return Contains((T) value);
        }

        /// <summary>
        /// Determines the index of a specific item in the <see cref="T:System.Collections.IList"/>.
        /// </summary>
        /// <param name="value">The object to locate in the <see cref="T:System.Collections.IList"/>.</param>
        /// <returns>
        /// The index of <paramref name="value"/> if found in the list; otherwise, -1.
        /// </returns>
        int IList.IndexOf(object value)
        {
            return IndexOf((T) value);
        }

        /// <summary>
        /// Adds an item to the <see cref="T:System.Collections.IList"/>.
        /// </summary>
        /// <param name="value">The object to add to the <see cref="T:System.Collections.IList"/>.</param>
        /// <returns>
        /// The position into which the new element was inserted, or -1 to indicate that the item was not inserted into the collection,
        /// </returns>
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"/> is read-only.-or- The <see cref="T:System.Collections.IList"/> has a fixed size. </exception>
        int IList.Add(object value)
        {
            Add((T) value);
            return Count - 1;
        }

        /// <summary>
        /// Inserts an item to the <see cref="T:System.Collections.IList"/> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which <paramref name="value"/> should be inserted.</param>
        /// <param name="value">The object to insert into the <see cref="T:System.Collections.IList"/>.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///   <paramref name="index"/> is not a valid index in the <see cref="T:System.Collections.IList"/>. </exception>
        ///
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"/> is read-only.-or- The <see cref="T:System.Collections.IList"/> has a fixed size. </exception>
        ///
        /// <exception cref="T:System.NullReferenceException">
        ///   <paramref name="value"/> is null reference in the <see cref="T:System.Collections.IList"/>.</exception>
        void IList.Insert(int index, object value)
        {
            Insert(index, (T) value);
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.IList"/>.
        /// </summary>
        /// <param name="value">The object to remove from the <see cref="T:System.Collections.IList"/>.</param>
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"/> is read-only.-or- The <see cref="T:System.Collections.IList"/> has a fixed size. </exception>
        void IList.Remove(object value)
        {
            Remove((T) value);
        }

        /// <summary>
        /// Adds a new item to the list.
        /// </summary>
        /// <returns>
        /// The item added to the list.
        /// </returns>
        /// <exception cref="T:System.NotSupportedException">
        ///   <see cref="P:System.ComponentModel.IBindingList.AllowNew"/> is false. </exception>
        object IBindingList.AddNew()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Sorts the list based on a <see cref="T:System.ComponentModel.PropertyDescriptor"/> and a <see cref="T:System.ComponentModel.ListSortDirection"/>.
        /// </summary>
        /// <param name="property">The <see cref="T:System.ComponentModel.PropertyDescriptor"/> to sort by.</param>
        /// <param name="direction">One of the <see cref="T:System.ComponentModel.ListSortDirection"/> values.</param>
        /// <exception cref="T:System.NotSupportedException">
        ///   <see cref="P:System.ComponentModel.IBindingList.SupportsSorting"/> is false. </exception>
        void IBindingList.ApplySort(PropertyDescriptor property, ListSortDirection direction)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Removes any sort applied using <see cref="M:System.ComponentModel.IBindingList.ApplySort(System.ComponentModel.PropertyDescriptor,System.ComponentModel.ListSortDirection)"/>.
        /// </summary>
        /// <exception cref="T:System.NotSupportedException">
        ///   <see cref="P:System.ComponentModel.IBindingList.SupportsSorting"/> is false. </exception>
        void IBindingList.RemoveSort()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Returns the index of the row that has the given <see cref="T:System.ComponentModel.PropertyDescriptor"/>.
        /// </summary>
        /// <param name="property">The <see cref="T:System.ComponentModel.PropertyDescriptor"/> to search on.</param>
        /// <param name="key">The value of the <paramref name="property"/> parameter to search for.</param>
        /// <returns>
        /// The index of the row that has the given <see cref="T:System.ComponentModel.PropertyDescriptor"/>.
        /// </returns>
        /// <exception cref="T:System.NotSupportedException">
        ///   <see cref="P:System.ComponentModel.IBindingList.SupportsSearching"/> is false. </exception>
        int IBindingList.Find(PropertyDescriptor property, object key)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Adds the <see cref="T:System.ComponentModel.PropertyDescriptor"/> to the indexes used for searching.
        /// </summary>
        /// <param name="property">The <see cref="T:System.ComponentModel.PropertyDescriptor"/> to add to the indexes used for searching.</param>
        void IBindingList.AddIndex(PropertyDescriptor property)
        {
        }

        /// <summary>
        /// Removes the <see cref="T:System.ComponentModel.PropertyDescriptor"/> from the indexes used for searching.
        /// </summary>
        /// <param name="property">The <see cref="T:System.ComponentModel.PropertyDescriptor"/> to remove from the indexes used for searching.</param>
        void IBindingList.RemoveIndex(PropertyDescriptor property)
        {
        }

        private void OnListChanged(ListChangedEventArgs e)
        {
            //thread safe
            ListChangedEventHandler handler;
            lock (this)
            {
                handler = ListChanged;
            }

            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void InnerCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    for (int i = 0; i < e.NewItems.Count; i++)
                    {
                        StartListeningToPropertyChanged(e.NewItems[i]);
                        OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, e.NewStartingIndex + i));
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    for (int i = 0; i < e.OldItems.Count; i++)
                    {
                        StopListeningToPropertyChanged(e.OldItems[i]);
                        OnListChanged(new ListChangedEventArgs(ListChangedType.ItemDeleted, e.OldStartingIndex + i));
                    }
                    break;
                case NotifyCollectionChangedAction.Move:
                    for (int i = 0; i < e.OldItems.Count; i++)
                    {
                        OnListChanged(new ListChangedEventArgs(ListChangedType.ItemMoved, e.NewStartingIndex + i,
                                                               e.OldStartingIndex + i));
                    }
                    break;
                default:
                    foreach (object item in e.OldItems)
                    {
                        StopListeningToPropertyChanged(item);
                    }
                    foreach (object item in e.NewItems)
                    {
                        StartListeningToPropertyChanged(item);
                    }
                    OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, 0));
                    break;
            }
        }

        private void StartListeningToPropertyChanged(object item)
        {
            var observable = item as INotifyPropertyChanged;
            if (observable != null)
            {
                observable.PropertyChanged += ItemPropertyChanged;
            }
        }

        private void StopListeningToPropertyChanged(object item)
        {
            var observable = item as INotifyPropertyChanged;
            if (observable != null)
            {
                observable.PropertyChanged -= ItemPropertyChanged;
            }
        }

        private void ItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, IndexOf((T) sender)));
        }
    }
}

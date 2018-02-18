using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace MvvmFx.Bindings.Interactivity
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class AttachableCollection<T> : IList<T>, ICollection<T>, IEnumerable<T>, INotifyCollectionChanged,
                                                    IAttachedObject
        where T : IDependencyObject
    {
        private readonly ObservableCollection<T> _items;

        internal AttachableCollection()
        {
            _items = new ObservableCollection<T>();
            CollectionChanged += OnCollectionChanged;
        }

        #region Implementation of IEnumerable

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Implementation of ICollection<T>

        /// <summary>
        /// Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param><exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.</exception>
        public void Add(T item)
        {
            _items.Add(item);
        }

        /// <summary>
        /// Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only. </exception>
        public void Clear()
        {
            _items.Clear();
        }

        /// <summary>
        /// Determines whether the <see cref="T:System.Collections.Generic.ICollection`1"/> contains a specific value.
        /// </summary>
        /// <returns>
        /// true if <paramref name="item"/> is found in the <see cref="T:System.Collections.Generic.ICollection`1"/>; otherwise, false.
        /// </returns>
        /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
        public bool Contains(T item)
        {
            return _items.Contains(item);
        }

        /// <summary>
        /// Copies the elements of the <see cref="T:System.Collections.Generic.ICollection`1"/> to an <see cref="T:System.Array"/>, starting at a particular <see cref="T:System.Array"/> index.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="T:System.Array"/> that is the destination 
        /// of the elements copied from <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// The <see cref="T:System.Array"/> must have zero-_itemsd indexing.</param>
        /// <param name="arrayIndex">The zero-based index in <paramref name="array"/> at which copying begins.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="array"/> is null.
        /// </exception><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="arrayIndex"/> is less than 0.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="array"/> is multidimensional.-or-The number of elements
        /// in the source <see cref="T:System.Collections.Generic.ICollection`1"/> is greater than the available space
        /// from <paramref name="arrayIndex"/> to the end of the destination <paramref name="array"/>.
        /// -or-Type <paramref name="T"/> cannot be cast automatically to the type of the destination <paramref name="array"/>.
        /// </exception>
        public void CopyTo(T[] array, int arrayIndex)
        {
            _items.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <returns>
        /// true if <paramref name="item"/> was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1"/>; otherwise, false. This method also returns false if <paramref name="item"/> is not found in the original <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </returns>
        /// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param><exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.</exception>
        public bool Remove(T item)
        {
            return _items.Remove(item);
        }

        /// <summary>
        /// Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <returns>
        /// The number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </returns>
        public int Count
        {
            get { return _items.Count; }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.
        /// </summary>
        /// <returns>
        /// true if the <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only; otherwise, false.
        /// </returns>
        public bool IsReadOnly
        {
            get { return false; }
        }

        #endregion

        #region Implementation of IList<T>

        /// <summary>
        /// Determines the index of a specific item in the <see cref="T:System.Collections.Generic.IList`1"/>.
        /// </summary>
        /// <returns>
        /// The index of <paramref name="item"/> if found in the list; otherwise, -1.
        /// </returns>
        /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.IList`1"/>.</param>
        public int IndexOf(T item)
        {
            return _items.IndexOf(item);
        }

        /// <summary>
        /// Inserts an item to the <see cref="T:System.Collections.Generic.IList`1"/> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which <paramref name="item"/> should be inserted.</param><param name="item">The object to insert into the <see cref="T:System.Collections.Generic.IList`1"/>.</param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index"/> is not a valid index in the <see cref="T:System.Collections.Generic.IList`1"/>.</exception><exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.IList`1"/> is read-only.</exception>
        public void Insert(int index, T item)
        {
            _items.Insert(index, item);
        }

        /// <summary>
        /// Removes the <see cref="T:System.Collections.Generic.IList`1"/> item at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the item to remove.</param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index"/> is not a valid index in the <see cref="T:System.Collections.Generic.IList`1"/>.</exception><exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.IList`1"/> is read-only.</exception>
        public void RemoveAt(int index)
        {
            _items.RemoveAt(index);
        }

        /// <summary>
        /// Gets or sets the element at the specified index.
        /// </summary>
        /// <returns>
        /// The element at the specified index.
        /// </returns>
        /// <param name="index">The zero-based index of the element to get or set.</param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index"/> is not a valid index in the <see cref="T:System.Collections.Generic.IList`1"/>.</exception><exception cref="T:System.NotSupportedException">The property is set and the <see cref="T:System.Collections.Generic.IList`1"/> is read-only.</exception>
        public T this[int index]
        {
            get { return _items[index]; }
            set { _items[index] = value; }
        }

        #endregion

        #region Implementation of INotifyCollectionChanged

        /// <summary>
        /// Occurs when the collection changes.
        /// </summary>
        public event NotifyCollectionChangedEventHandler CollectionChanged
        {
            add { _items.CollectionChanged += value; }
            remove { _items.CollectionChanged -= value; }
        }

        #endregion

        #region IAttachedObject

        /// <summary>
        /// Attaches the specified <see cref="MvvmFx.Bindings.IDependencyObject"/> to the collection
        /// </summary>
        /// <param name="dependencyObject">The <see cref="MvvmFx.Bindings.IDependencyObject"/> to attach</param>
        public void Attach(IDependencyObject dependencyObject)
        {
            if (dependencyObject != AssociatedObject)
            {
                if (AssociatedObject != null)
                {
                    throw new InvalidOperationException();
                }
                OnAttached();
            }
        }

        /// <summary>
        /// Detaches the currently associated <see cref="MvvmFx.Bindings.IDependencyObject"/>
        /// </summary>
        public void Detach()
        {
            OnDetaching();
            AssociatedObject = null;
        }

        /// <summary>
        /// Gets the associated object.
        /// </summary>
        /// <remarks>Represents the <see cref="MvvmFx.Bindings.IDependencyObject"/> this instance is attached to.</remarks>
        public IDependencyObject AssociatedObject { get; private set; }

        #endregion

        #region Abstracts

        /// <summary>
        /// Implemented by derived class notifies an item was added
        /// </summary>
        /// <param name="item">Item added</param>
        internal abstract void ItemAdded(T item);

        /// <summary>
        /// Implemented by derived class notifies an item was removed
        /// </summary>
        /// <param name="item">Item removed</param>
        internal abstract void ItemRemoved(T item);

        /// <summary>
        /// Notifies that a <see cref="MvvmFx.Bindings.IDependencyObject"/> has been attached
        /// </summary>
        protected abstract void OnAttached();

        /// <summary>
        /// Notifies that a <see cref="MvvmFx.Bindings.IDependencyObject"/> is detaching. This before
        /// </summary>
        protected abstract void OnDetaching();

        #endregion

        #region Utils

        /// <summary>
        /// Handles elements added to or removed from the collection
        /// </summary>
        /// <param name="sender">source of the event</param>
        /// <param name="e">arguments</param>
        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (T item in e.NewItems)
                    {
                        try
                        {
                            VerifyAdd(item);
                            ItemAdded(item);
                        }
                        finally
                        {
                            _items.Insert(_items.IndexOf(item), item);
                        }
                    }
                    break;

                case NotifyCollectionChangedAction.Remove:
                    foreach (T item in e.OldItems)
                    {
                        ItemRemoved(item);
                        _items.Remove(item);
                    }
                    break;

                case NotifyCollectionChangedAction.Replace:
                    foreach (T item in e.OldItems)
                    {
                        ItemRemoved(item);
                        _items.Remove(item);
                    }
                    foreach (T item in e.NewItems)
                    {
                        try
                        {
                            VerifyAdd(item);
                            ItemAdded(item);
                        }
                        finally
                        {
                            _items.Insert(_items.IndexOf(item), item);
                        }
                    }
                    break;

                case (NotifyCollectionChangedAction.Replace | NotifyCollectionChangedAction.Remove):
                    break;

                case NotifyCollectionChangedAction.Reset:
                    foreach (T item in _items)
                    {
                        ItemRemoved(item);
                    }

                    _items.Clear();

                    foreach (T item in this)
                    {
                        VerifyAdd(item);
                        ItemAdded(item);
                    }
                    break;

                default:
                    return;
            }
        }

        /// <summary>
        /// Verifies an item is not already present in the collection
        /// </summary>
        /// <param name="item">Item to verify</param>
        private void VerifyAdd(T item)
        {
            if (_items.Contains(item))
            {
                throw new InvalidOperationException();
            }
        }

        #endregion
    }
}

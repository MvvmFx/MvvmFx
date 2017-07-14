using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace MvvmFx.CaliburnMicro
{
    /// <summary>
    /// Provides a generic collection that supports data binding and is observable.
    /// </summary>
    /// <typeparam name="T">The item Type.</typeparam>
    [Serializable]
    public class BindableList<T> : BindingList<T>, IObservableCollection<T>
    {
        /// <summary>
        /// Occurs when the collection changes.
        /// </summary>
        public event NotifyCollectionChangedEventHandler CollectionChanged = delegate { };

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        [field: NonSerialized]
        private bool _isNotifying;

        /// <summary>
        /// Initializes a new instance of the <see cref="BindableList{T}"/> class.
        /// </summary>
        public BindableList()
        {
            IsNotifying = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BindableList{T}"/> class,
        /// using the given <see cref="IEnumerable{T}"/> collection.
        /// </summary>
        /// <param name="collection">The collection.</param>
        public BindableList(IEnumerable<T> collection)
        {
            IsNotifying = true;
            AddRange(collection);
        }

        /// <summary>
        /// Enables/Disables property change notification.
        /// </summary>
        public bool IsNotifying
        {
            get { return _isNotifying; }
            set { _isNotifying = value; }
        }

        /// <summary>
        /// Notifies subscribers of the property change.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        public void NotifyOfPropertyChange(string propertyName)
        {
            if (IsNotifying)
            {
                Execute.OnUIThread(() => RaisePropertyChangedEventImmediately(new PropertyChangedEventArgs(propertyName)));
            }
        }

        /// <summary>
        /// Raises the <see cref="E:ListChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="ListChangedEventArgs"/> instance containing the event data.</param>
        protected override void OnListChanged(ListChangedEventArgs e)
        {
            if (IsNotifying)
            {
                Execute.OnUIThread(() => base.OnListChanged(e));
            }
        }

        /// <summary>
        /// Inserts the item.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="item">The item.</param>
        protected override void InsertItem(int index, T item)
        {
            Execute.OnUIThread(() => base.InsertItem(index, item));
        }

        private void RaisePropertyChangedEventImmediately(PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Raises a change notification indicating that all bindings should be refreshed.
        /// </summary>
        public void Refresh()
        {
            Execute.OnUIThread(() => OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, 0)));
        }

        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="items">The items.</param>
        public void AddRange(IEnumerable<T> items)
        {
            Execute.OnUIThread(() =>
            {
                var previousNotificationSetting = IsNotifying;
                IsNotifying = false;
                var index = Count;
                foreach (var item in items)
                {
                    InsertItem(index, item);
                    index++;
                }
                IsNotifying = previousNotificationSetting;

                OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, 0));
            });
        }

        /// <summary>
        /// Removes the range.
        /// </summary>
        /// <param name="items">The items.</param>
        public void RemoveRange(IEnumerable<T> items)
        {
            Execute.OnUIThread(() =>
            {
                var previousNotificationSetting = IsNotifying;
                IsNotifying = false;
                foreach (var item in items)
                {
                    var index = IndexOf(item);
                    RemoveItem(index);
                }
                IsNotifying = previousNotificationSetting;
                OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, 0));
            });
        }
    }
}
namespace MvvmFx.CaliburnMicro.ComponentProxy
{
    using System;
#if WINFORMS
    using System.ComponentModel;
    using System.Windows.Forms;
#else
    using Wisej.Web;
    using Component = Wisej.Web.Component;

#endif

    /// <summary>
    /// A base class for various implementations of<see cref="ComponentProxyBase{T}" /> 
    /// that maintain an <see cref="Component"/> item.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Control" />
    /// <seealso cref="IComponentProxy{T}" />
    public abstract class ComponentProxyBase<T> : Control, IComponentProxy<T> where T : Component
    {
        #region Private fields

        private bool _eventsWired;

        #endregion

        #region Constructors

        private ComponentProxyBase()
        {
            // force to use parametrized constructor
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentProxyBase{T}" /> class 
        /// for the specified <see cref="T" /> instance.
        /// </summary>
        /// <param name="item">The <see cref="Component"/> item.</param>
        /// <param name="parent">The parent <see cref="Control"/>.</param>
        /// <param name="wireEvents">if set to <c>true</c>, the constructor will wire the item events.</param>
        protected internal ComponentProxyBase(T item, Control parent, bool wireEvents)
        {
            Parent = parent;
            Item = item;

            /*Name = item.Name;
            Enabled = item.Enabled;
            Visible = item.Visible;
            Tag = item.Tag;*/

            if (wireEvents)
                WireEvents();
        }

        #endregion

        #region IDisposable implementation

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="Control" /> and its child controls and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            UnwireEvents();

            /*for (var index = _item.MenuItems.Count - 1; index >= 0; index--)
            {
                _item.MenuItems[index].Dispose();
            }*/

            Item.Dispose();
            base.Dispose(disposing);
        }

        #endregion

        #region IComponentProxy members

        /// <summary>
        /// Gets the proxy item.
        /// </summary>
        /// <value>
        /// The proxy item.
        /// </value>
        public T Item { get; }

#if WISEJ
        /// <summary>
        /// Returns a dynamic object that can be used to store custom data in relation to this control.
        /// </summary>
        public new dynamic UserData
        {
            get { return Item.UserData; }
        }
#endif

        /// <summary>
        /// Wires the events.
        /// </summary>
        public virtual void WireEvents()
        {
            if (_eventsWired)
                return;

            //EnabledChanged += MenuItemProxy_EnabledChanged;
            //VisibleChanged += MenuItemProxy_VisibleChanged;

            //_item.Click += item_Click;
            Item.Disposed += item_Disposed;

            _eventsWired = true;
        }

        /// <summary>
        /// Unwires the events.
        /// </summary>
        public virtual void UnwireEvents()
        {
            if (!_eventsWired)
                return;

            Item.Disposed -= item_Disposed;
            //_item.Click -= item_Click;
            //VisibleChanged -= MenuItemProxy_VisibleChanged;
            //EnabledChanged -= MenuItemProxy_EnabledChanged;

            _eventsWired = false;
        }

        private void item_Disposed(object sender, EventArgs e)
        {
            UnwireEvents();
            Dispose();
        }

        #endregion

        /*private void item_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }*/

        /*private void MenuItemProxy_EnabledChanged(object sender, EventArgs e)
        {
            if (_isEnabledChanging)
                return;

            _isEnabledChanging = true;
            _item.Enabled = Enabled;
            _isEnabledChanging = false;
        }*/

        /*private void MenuItemProxy_VisibleChanged(object sender, EventArgs e)
        {
            if (_isVisibleChanging)
                return;

            _isVisibleChanging = true;
            _item.Visible = Visible;
            _isVisibleChanging = false;
        }*/
    }
}
namespace MvvmFx.CaliburnMicro
{
    using System;
    using System.ComponentModel;
    using Wisej.Web;

    /// <summary>
    /// Proxy class for <see cref="MenuItem"/> components.
    /// </summary>
    [DefaultProperty("Name")]
    public class MenuItemProxy : Control
    {
        private bool _eventsWired;
        private bool _isEnabledChanging;
        private bool _isVisibleChanging;

        private readonly MenuItem _item;

        /// <summary>
        /// Gets the proxy item.
        /// </summary>
        /// <value>
        /// The proxy item.
        /// </value>
        public MenuItem Item
        {
            get { return _item; }
        }

        private MenuItemProxy()
        {
            // force to use parametrized constructor
        }

        protected override void Dispose(bool disposing)
        {
            UnwireEvents();
            for (var index = _item.MenuItems.Count - 1; index >= 0; index--)
            {
                _item.MenuItems[index].Dispose();
            }

            _item.Dispose();
            base.Dispose(disposing);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuItemProxy" /> class, for the specified <see cref="MenuItem" />.
        /// </summary>
        /// <param name="item">The tool strip item.</param>
        /// <param name="parent">The parent Control.</param>
        /// <param name="wireEvents">if set to <c>true</c>, the constructor will wire the item events.</param>
        public MenuItemProxy(MenuItem item, Control parent, bool wireEvents)
        {
            Parent = parent;
            _item = item;
            Name = item.Name;
            Enabled = item.Enabled;
            Visible = item.Visible;
            Tag = item.Tag;

            if (wireEvents)
                WireEvents();
        }

        /// <summary>
        /// Wires the events.
        /// </summary>
        public void WireEvents()
        {
            if (_eventsWired)
                return;

            EnabledChanged += MenuItemProxy_EnabledChanged;
            VisibleChanged += MenuItemProxy_VisibleChanged;
            _item.Click += item_Click;
            _item.Disposed += item_Disposed;

            _eventsWired = true;
        }

        /// <summary>
        /// Unwires the events.
        /// </summary>
        public void UnwireEvents()
        {
            if (!_eventsWired)
                return;

            _item.Disposed -= item_Disposed;
            _item.Click -= item_Click;
            VisibleChanged -= MenuItemProxy_VisibleChanged;
            EnabledChanged -= MenuItemProxy_EnabledChanged;

            _eventsWired = false;
        }

        private void item_Disposed(object sender, EventArgs e)
        {
            UnwireEvents();
            Dispose();
        }

        private void item_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }

        private void MenuItemProxy_EnabledChanged(object sender, EventArgs e)
        {
            if (_isEnabledChanging)
                return;

            _isEnabledChanging = true;
            _item.Enabled = Enabled;
            _isEnabledChanging = false;
        }

        private void MenuItemProxy_VisibleChanged(object sender, EventArgs e)
        {
            if (_isVisibleChanging)
                return;

            _isVisibleChanging = true;
            _item.Visible = Visible;
            _isVisibleChanging = false;
        }
    }
}
namespace MvvmFx.CaliburnMicro.ComponentProxy
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

        /// <summary>
        /// Gets the <see cref="MenuItem"/> component item.
        /// </summary>
        /// <value>
        /// The component item.
        /// </value>
        public MenuItem Item { get; }

        /// <summary>
        /// Returns a dynamic object that can be used to store custom data in relation to this control.
        /// </summary>
        public new dynamic UserData
        {
            get { return Item.UserData; }
        }

        private MenuItemProxy()
        {
            // force to use parametrized constructor
        }

        /// <summary>Dispose the control.</summary>
        /// <param name="disposing">true when this method is called by the application rather than a finalizer.</param>
        protected override void Dispose(bool disposing)
        {
            UnwireEvents();
            for (var index = Item.MenuItems.Count - 1; index >= 0; index--)
            {
                Item.MenuItems[index].Dispose();
            }

            Item.Dispose();
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
            Item = item;
            Name = item.Name;
            Enabled = item.Enabled;
            Visible = item.Visible;
            Tag = item.Tag;

            if (wireEvents)
                WireEvents();
        }

        /// <summary>
        /// Wires the proxy events.
        /// </summary>
        public void WireEvents()
        {
            if (_eventsWired)
                return;

            EnabledChanged += MenuItemProxy_EnabledChanged;
            VisibleChanged += MenuItemProxy_VisibleChanged;
            Item.Click += item_Click;
            Item.Disposed += item_Disposed;

            _eventsWired = true;
        }

        /// <summary>
        /// Unwires the proxy events.
        /// </summary>
        public void UnwireEvents()
        {
            if (!_eventsWired)
                return;

            Item.Disposed -= item_Disposed;
            Item.Click -= item_Click;
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
            Item.Enabled = Enabled;
            _isEnabledChanging = false;
        }

        private void MenuItemProxy_VisibleChanged(object sender, EventArgs e)
        {
            if (_isVisibleChanging)
                return;

            _isVisibleChanging = true;
            Item.Visible = Visible;
            _isVisibleChanging = false;
        }
    }
}
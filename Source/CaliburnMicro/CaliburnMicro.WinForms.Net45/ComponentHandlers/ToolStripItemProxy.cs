namespace MvvmFx.CaliburnMicro.ComponentHandlers
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

    /// <summary>
    /// Proxy class for <see cref="ToolStripItem"/> components.
    /// </summary>
    [DefaultProperty("Name")]
    public class ToolStripItemProxy : Control
    {
        private bool _eventsWired;
        private bool _isEnabledChanging;
        private bool _isVisibleChanging;

        /// <summary>
        /// Gets the <see cref="ToolStripItem"/> component item.
        /// </summary>
        /// <value>
        /// The component item.
        /// </value>
        public ToolStripItem Item { get; }

        private ToolStripItemProxy()
        {
            // force to use parametrized constructor
        }

        /// <summary>Releases the unmanaged resources used by the <see cref="T:System.Windows.Forms.Control" /> and its child controls and optionally releases the managed resources.</summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources. </param>
        protected override void Dispose(bool disposing)
        {
            UnwireEvents();
            if (Item is ToolStripDropDownItem)
            {
                var dropDownItem = Item as ToolStripDropDownItem;

                for (var index = dropDownItem.DropDownItems.Count - 1; index >= 0; index--)
                {
                    dropDownItem.DropDownItems[index].Dispose();
                }
            }

            Item.Dispose();
            base.Dispose(disposing);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripItemProxy" /> class, for the specified <see cref="ToolStripItem" />.
        /// </summary>
        /// <param name="item">The tool strip item.</param>
        /// <param name="parent">The parent Control.</param>
        /// <param name="wireEvents">if set to <c>true</c>, the constructor will wire the item events.</param>
        public ToolStripItemProxy(ToolStripItem item, Control parent, bool wireEvents)
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

            EnabledChanged += ToolStripItemProxy_EnabledChanged;
            VisibleChanged += ToolStripItemProxy_VisibleChanged;

            Item.EnabledChanged += Item_EnabledChanged;
            Item.VisibleChanged += Item_VisibleChanged;
            Item.DoubleClick += item_DoubleClick;
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
            Item.DoubleClick -= item_DoubleClick;
            Item.VisibleChanged -= Item_VisibleChanged;
            Item.EnabledChanged -= Item_EnabledChanged;

            VisibleChanged -= ToolStripItemProxy_VisibleChanged;
            EnabledChanged -= ToolStripItemProxy_EnabledChanged;

            _eventsWired = false;
        }

        private void item_Disposed(object sender, EventArgs e)
        {
            UnwireEvents();
            Dispose();
        }

        private void item_DoubleClick(object sender, EventArgs e)
        {
            OnDoubleClick(e);
        }

        private void item_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }

        private void Item_EnabledChanged(object sender, EventArgs e)
        {
            if (_isEnabledChanging)
                return;

            _isEnabledChanging = true;
            Enabled = Item.Enabled;
            _isEnabledChanging = false;
        }

        private void Item_VisibleChanged(object sender, EventArgs e)
        {
            if (_isVisibleChanging)
                return;

            _isVisibleChanging = true;
            Visible = Item.Visible;
            _isVisibleChanging = false;
        }

        private void ToolStripItemProxy_EnabledChanged(object sender, EventArgs e)
        {
            if (_isEnabledChanging)
                return;

            _isEnabledChanging = true;
            Item.Enabled = Enabled;
            _isEnabledChanging = false;
        }

        private void ToolStripItemProxy_VisibleChanged(object sender, EventArgs e)
        {
            if (_isVisibleChanging)
                return;

            _isVisibleChanging = true;
            Item.Visible = Visible;
            _isVisibleChanging = false;
        }
    }
}